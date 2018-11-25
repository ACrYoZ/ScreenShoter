using ScreenShoter.Classes;
using ScreenShoter.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using upScreenLib;

namespace ScreenShoter
{
    public partial class frmCapture : Form
    {
        Settings settings;

        private Hook _hookGlobal;
        private Hook _hookClipboard;
        private Hook _hookSelectArea;
        private Hook _hookBackgroundWindow;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        public frmCapture()
        {
            //Проверяем активна ли программа в данный момент
            string procName = Process.GetCurrentProcess().ProcessName;
            
            // получаем список процессов
            Process[] processes = Process.GetProcessesByName(procName);

            if (processes.Length > 1)
            {
                MessageBox.Show(procName + " уже запущен");
                //Необходимо вызывате метод закрывающий форму, иначе будет висеть пустая форма.
                this.Close();
                return;
            }
            else
            {
                InitializeComponent();

                //Установка хуков и инициализация настроек
                Init();
                
                //Инициализация иконки в трее
                notifIcon = new NotifyIcon();
                notifIcon.Icon = SystemIcons.Asterisk;
                notifIcon.Visible = true;
                notifIcon.Click += NotifIcon_Click;
                notifIcon.ContextMenuStrip = ctxMenu;
            }
        }

        private void Init()
        {
            settings = new Settings();


            keybd_event(settings.globalScreenKey, 0x45, 0x1, (UIntPtr)0);
            keybd_event(settings.clipboardScreenKey, 0x45, 0x1, (UIntPtr)0);
            keybd_event(settings.areaScreenKey, 0x45, 0x1, (UIntPtr)0);
            keybd_event(settings.backgroundScreenKey, 0x45, 0x1, (UIntPtr)0);


            // 0x90 клавиша NumLock || 0x74 - F5
            _hookGlobal = new Hook(settings.globalScreenKey, settings.ctrlForGlobal); //Передаем код клавиши на которую ставим хук, тут это CapsLock

            _hookGlobal.KeyPressed += new KeyPressEventHandler(_hook_KeyPressed_GlobalScreen);
            _hookGlobal.SetHook();

            //Hook для Clipboard
            _hookClipboard = new Hook(settings.clipboardScreenKey, settings.ctrlForClipboard);

            _hookClipboard.KeyPressed += new KeyPressEventHandler(_hook_KeyPressed_ClipboardScreen);
            _hookClipboard.SetHook();

            //Hook для выбора области
            _hookSelectArea = new Hook(settings.areaScreenKey, settings.ctrlForArea);

            _hookSelectArea.KeyPressed += new KeyPressEventHandler(_hook_KeyPressed_SelectAreaScreen);
            _hookSelectArea.SetHook();

            //Hook для скрина окна
            _hookBackgroundWindow = new Hook(settings.backgroundScreenKey, settings.ctrlForBackground);

            _hookBackgroundWindow.KeyPressed += new KeyPressEventHandler(_hook_KeyPressed_BackgroundScreen);
            _hookBackgroundWindow.SetHook();
        }

        #region ScreenShots methods
        //Сделать скриншот всего экрана
        private void btnMakeScreen_Click(object sender, EventArgs e)
        {
            this.Hide();

            CaptureControl.CaptureScreen = Screen.FromPoint(Cursor.Position);
            CaptureControl.CaptFullScreen();
        }

        //Сделать скриншот из буфера обмена
        private void btnMakeScreenClip_Click(object sender, EventArgs e)
        {
            //Проверка на корректность данных в буфере обмена (картинка ли это?). Если нет - выход из метода.
            if(!Clipboard.ContainsImage() && !Common.ImageFileInClipboard && !Common.ImageUrlInClipboard) { return; }

            this.Hide();

            CaptureControl.CaptFromClipboard();
        }

        //Сделать скриншот выделенной области
        private void btnMakeScreenArea_Click(object sender, EventArgs e)
        {
            this.Hide();

            SelectionBox sb = new SelectionBox();
            sb.ShowDialog();
        }

        //Сделать скриншот окна
        //TODO(fix): Есть ошибка, если открыто два экземпляра окна которое мы захватываем.
        private void btnCaptBackground_Click(object sender, EventArgs e)
        {
            this.Opacity = 0;
            this.Hide();

            //получаем окно
            int hWindow = User32.GetForegroundWindow();
            User32.RECT bounds = new User32.RECT();
            User32.GetWindowRect((IntPtr)hWindow, ref bounds);

            int width = bounds.right - bounds.left;
            int height = bounds.bottom - bounds.top;
            User32.WINDOWPLACEMENT wp = new User32.WINDOWPLACEMENT();
            User32.GetWindowPlacement((IntPtr)hWindow, ref wp);
            int x;
            int y;

            if (wp.showCmd == (int)User32.WindowState.SW_SHOWMAXIMIZED)
            {
                x = wp.ptMaxPosition.X;
                y = wp.ptMaxPosition.Y;
            }
            else
            {
                x = wp.rcNormalPosition.X;
                y = wp.rcNormalPosition.Y;
            }

            if ((x + width) > Screen.PrimaryScreen.WorkingArea.Width)
                width = width - ((x + width) - Screen.PrimaryScreen.WorkingArea.Width);

            if ((y + height) > Screen.PrimaryScreen.WorkingArea.Height)
                height = height - ((y + height) - Screen.PrimaryScreen.WorkingArea.Height);


            CaptureControl.CaptBackground(width, height, x, y);
            this.Opacity = 100;
        }

        //События нажатия клавиш
        void _hook_KeyPressed_GlobalScreen(object sender, KeyPressEventArgs e) 
        {
            CaptureControl.CaptureScreen = Screen.FromPoint(Cursor.Position);
            CaptureControl.CaptFullScreen();
        }

        void _hook_KeyPressed_ClipboardScreen(object sender, KeyPressEventArgs e)
        {
            //Проверка на корректность данных в буфере обмена (картинка ли это?). Если нет - выход из метода.
            if (!Clipboard.ContainsImage() && !Common.ImageFileInClipboard && !Common.ImageUrlInClipboard) { return; }

            CaptureControl.CaptFromClipboard();
        }

        void _hook_KeyPressed_SelectAreaScreen(object sender, KeyPressEventArgs e)
        {
            SelectionBox sb = new SelectionBox();
            sb.ShowDialog();
        }

        void _hook_KeyPressed_BackgroundScreen(object sender, KeyPressEventArgs e)
        {
            //получаем окно
            int hWindow = User32.GetForegroundWindow();
            User32.RECT bounds = new User32.RECT();
            User32.GetWindowRect((IntPtr)hWindow, ref bounds);

            int width = bounds.right - bounds.left;
            int height = bounds.bottom - bounds.top;
            User32.WINDOWPLACEMENT wp = new User32.WINDOWPLACEMENT();
            User32.GetWindowPlacement((IntPtr)hWindow, ref wp);
            int x;
            int y;

            if (wp.showCmd == (int)User32.WindowState.SW_SHOWMAXIMIZED)
            {
                x = wp.ptMaxPosition.X;
                y = wp.ptMaxPosition.Y;
            }
            else
            {
                x = wp.rcNormalPosition.X;
                y = wp.rcNormalPosition.Y;
            }

            if ((x + width) > Screen.PrimaryScreen.WorkingArea.Width)
                width = width - ((x + width) - Screen.PrimaryScreen.WorkingArea.Width);

            if ((y + height) > Screen.PrimaryScreen.WorkingArea.Height)
                height = height - ((y + height) - Screen.PrimaryScreen.WorkingArea.Height);


            CaptureControl.CaptBackground(width, height, x, y);
        }

        #endregion

        private void NotifIcon_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                this.Show();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void tlsmExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tlsmSettings_Click(object sender, EventArgs e)
        {
            frmSettings settings = new frmSettings();
            settings.FormClosed += Settings_FormClosed;

            settings.ShowDialog();
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Устанавливаем хуки
            Init();
        }
    }

    //Вспомогательный класс
    class User32
    {
        public enum WindowState
        {
            SW_SHOWNORMAL = 1,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMAXIMIZED = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);
    }
}
