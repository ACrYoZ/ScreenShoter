using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShoter.Classes
{
    class Hook
    {

        #region Declare WinAPI functions
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        #endregion
        #region Constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WH_KEYDOWN = 0x0100;
        #endregion

        //Используем ли Ctrl
        bool useCtrl;

        bool ctrlPressed;

        // код клавиши на которую ставим хук
        private int _key;
        public event KeyPressEventHandler KeyPressed;

        private delegate IntPtr KeyboardHookProc(int code, IntPtr wParam, IntPtr lParam);
        private KeyboardHookProc _proc;
        private IntPtr _hHook = IntPtr.Zero;

        public Hook(int keyCode, bool useCtrl)
        {
            this.useCtrl = useCtrl;

            _key = keyCode;
            _proc = HookProc;
        }

        public void SetHook()
        {
            var hInstance = LoadLibrary("User32");
            _hHook = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, hInstance, 0);
        }

        public void Dispose()
        {
            UnHook();
        }

        public void UnHook()
        {
            UnhookWindowsHookEx(_hHook);
        }

        private IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (useCtrl)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                // 162 - Код Left Ctrl | 163 - Код Right Ctrl
                if (vkCode == 162 || vkCode == 163)
                {
                    //Запоминаем нажатие клавиши
                    ctrlPressed = true;
                }

                if (ctrlPressed && vkCode == _key)
                {

                    // бросаем событие
                    if (KeyPressed != null)
                    {
                        //Сбрасываем нажатие Ctrl
                        ctrlPressed = false;
                        KeyPressed(this, new KeyPressEventArgs(Convert.ToChar(code)));
                    }
                }
            }
            else if(!useCtrl)
            {
                if ((code >= 0 && wParam == (IntPtr)WH_KEYDOWN) && Marshal.ReadInt32(lParam) == _key)
                {

                    // бросаем событие
                    if (KeyPressed != null)
                    {
                        KeyPressed(this, new KeyPressEventArgs(Convert.ToChar(code)));
                    }
                }
            }
            else
            {
                //Do something
            }

            // пробрасываем хук дальше
            return CallNextHookEx(_hHook, code, (int)wParam, lParam);
        }
    }
}
