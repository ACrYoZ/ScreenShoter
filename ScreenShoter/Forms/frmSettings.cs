using ScreenShoter.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenShoter.Forms
{
    public partial class frmSettings : Form
    {
        Settings settings;

        [DllImport("user32.dll")]
        static extern int MapVirtualKey(int uCode, uint uMapType);

        public frmSettings()
        {
            InitializeComponent();

            //Инициализируем настройки
            settings = new Settings();

            #region Установка значений в компоненты

            //Получаем путь куда сохраняются файлы и отображаем его в TextBox
            txbPath.Text = settings.fileSavePath;
            //Получаем кол-во символов генерируемых в имени файла и выводим их в numeric up down
            nudFileNameLength.Value = settings.fileNameLength;
            //Получаем горячие клавиши и выводим их в соответствующие поля
            txbKeyAreaScr.Text = Properties.Settings.Default.HotKeyArea;
            txbKeyBackgroundScr.Text = Properties.Settings.Default.HotKeyBack;
            txbKeyClipboardScr.Text = Properties.Settings.Default.HotKeyClip;
            txbKeyGlobalScr.Text = Properties.Settings.Default.HotKeyGlobal;
            //Получаем значение установлен ли Ctrl
            chbUseCtrlGlobalScr.Checked = settings.ctrlForGlobal;
            chbUseCtrlClipboardScr.Checked = settings.ctrlForClipboard;
            chbUseCtrlBackgroundScr.Checked = settings.ctrlForBackground;
            chbUseCtrlAreaScr.Checked = settings.ctrlForArea;

            #endregion

        }

        #region Обработчики событий

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolder= new FolderBrowserDialog();
            
            if(openFolder.ShowDialog() == DialogResult.OK)
            {
                txbPath.Text = openFolder.SelectedPath;

                //Сохраняем изменение настройки;
                settings.SaveFilePath(openFolder.SelectedPath);
            }
        }

        private void btnSetKeyGlobalScr_Click(object sender, EventArgs e)
        {
            txbKeyGlobalScr.Text = "Нажмите клавишу";
        }

        private void btnSetKeyGlobalScr_KeyPress(object sender, KeyPressEventArgs e)
        { 
            txbKeyGlobalScr.Text = e.KeyChar.ToString();
            WriteKey(e, 1);

            //Сохраняем локально текст настроек. Т.к из класса Settings не выгрузим, ибо там
            //хранится байтовое представление клавиши
            Properties.Settings.Default.HotKeyGlobal = txbKeyGlobalScr.Text;

            Properties.Settings.Default.Save();  // Сохраняем переменные.
        }

        private void btnSetKeyAreaScr_Click(object sender, EventArgs e)
        {
            txbKeyAreaScr.Text = "Нажмите клавишу";
        }

        private void btnSetKeyAreaScr_KeyPress(object sender, KeyPressEventArgs e)
        {
            txbKeyAreaScr.Text = e.KeyChar.ToString();
            WriteKey(e, 2);

            //Сохраняем локально текст настроек. Т.к из класса Settings не выгрузим, ибо там
            //хранится байтовое представление клавиши
            Properties.Settings.Default.HotKeyArea = txbKeyAreaScr.Text;

            Properties.Settings.Default.Save();  // Сохраняем переменные.
        }

        private void btnSetKeyClipboardScr_Click(object sender, EventArgs e)
        {
            txbKeyClipboardScr.Text = "Нажмите клавишу";
        }

        private void btnSetKeyClipboardScr_KeyPress(object sender, KeyPressEventArgs e)
        {
            txbKeyClipboardScr.Text = e.KeyChar.ToString();
            WriteKey(e, 3);

            //Сохраняем локально текст настроек. Т.к из класса Settings не выгрузим, ибо там
            //хранится байтовое представление клавиши
            Properties.Settings.Default.HotKeyClip = txbKeyClipboardScr.Text;

            Properties.Settings.Default.Save();  // Сохраняем переменные.
        }

        private void btnSetKeyBackgroundScr_Click(object sender, EventArgs e)
        {
            txbKeyBackgroundScr.Text = "Нажмите клавишу";
        }

        private void btnSetKeyBackgroundScr_KeyPress(object sender, KeyPressEventArgs e)
        {
            txbKeyBackgroundScr.Text = e.KeyChar.ToString();
            WriteKey(e, 4);

            //Сохраняем локально текст настроек. Т.к из класса Settings не выгрузим, ибо там
            //хранится байтовое представление клавиши
            Properties.Settings.Default.HotKeyBack = txbKeyBackgroundScr.Text;

            Properties.Settings.Default.Save();  // Сохраняем переменные.
        }

        private void nudFileNameLength_ValueChanged(object sender, EventArgs e)
        {
            settings.SaveFileLength((int)nudFileNameLength.Value);
        }

        private void chbUseCtrlGlobalScr_CheckedChanged(object sender, EventArgs e)
        {
            settings.SaveCtrlForGlobal(chbUseCtrlGlobalScr.Checked);
        }

        private void chbUseCtrlAreaScr_CheckedChanged(object sender, EventArgs e)
        {
            settings.SaveCtrlForArea(chbUseCtrlAreaScr.Checked);
        }

        private void chbUseCtrlClipboardScr_CheckedChanged(object sender, EventArgs e)
        {
            settings.SaveCtrlForClip(chbUseCtrlClipboardScr.Checked);
        }

        private void chbUseCtrlBackgroundScr_CheckedChanged(object sender, EventArgs e)
        {
            settings.SaveCtrlForBackground(chbUseCtrlBackgroundScr.Checked);
        }

        #endregion

        //Костыль...
        private void WriteKey(KeyPressEventArgs e, int mode)
        {
            string key = e.KeyChar.ToString();
            //Gloabal
            if (mode == 1)
            {
                switch (key.ToUpper())
                {
                    case "Q":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "W":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "E":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "R":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "T":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Y":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "U":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "I":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "O":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "P":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "A":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "S":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "D":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "F":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "G":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "H":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "J":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "K":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "L":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Z":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "X":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "C":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "V":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "B":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "N":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "M":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    case "Й":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "Ц":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "У":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "К":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "Е":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Н":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "Г":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "Ш":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "Щ":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "З":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "Ф":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "Ы":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "В":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "А":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "П":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "Р":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "О":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "Л":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "Д":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Я":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "Ч":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "С":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "М":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "И":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "Т":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "Ь":
                        settings.SaveGlobalScrKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    default:
                        MessageBox.Show("Невозможно задать данную клавишу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            //Area
            else if (mode == 2)
            {
                switch (key.ToUpper())
                {
                    case "Q":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "W":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "E":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "R":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "T":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Y":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "U":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "I":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "O":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "P":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "A":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "S":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "D":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "F":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "G":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "H":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "J":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "K":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "L":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Z":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "X":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "C":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "V":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "B":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "N":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "M":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    case "Й":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "Ц":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "У":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "К":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "Е":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Н":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "Г":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "Ш":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "Щ":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "З":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "Ф":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "Ы":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "В":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "А":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "П":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "Р":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "О":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "Л":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "Д":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Я":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "Ч":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "С":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "М":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "И":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "Т":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "Ь":
                        settings.SaveAreaScrKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    default:
                        MessageBox.Show("Невозможно задать данную клавишу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            //Clipboard
            else if (mode == 3)
            {
                switch (key.ToUpper())
                {
                    case "Q":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "W":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "E":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "R":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "T":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Y":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "U":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "I":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "O":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "P":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "A":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "S":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "D":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "F":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "G":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "H":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "J":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "K":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "L":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Z":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "X":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "C":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "V":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "B":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "N":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "M":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    case "Й":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "Ц":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "У":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "К":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "Е":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Н":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "Г":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "Ш":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "Щ":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "З":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "Ф":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "Ы":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "В":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "А":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "П":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "Р":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "О":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "Л":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "Д":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Я":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "Ч":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "С":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "М":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "И":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "Т":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "Ь":
                        settings.SaveClipScreenKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    default:
                        MessageBox.Show("Невозможно задать данную клавишу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            //Background
            else if (mode == 4)
            {
                switch (key.ToUpper())
                {
                    case "Q":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "W":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "E":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "R":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "T":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Y":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "U":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "I":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "O":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "P":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "A":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "S":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "D":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "F":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "G":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "H":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "J":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "K":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "L":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Z":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "X":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "C":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "V":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "B":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "N":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "M":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    case "Й":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_Q);
                        break;
                    case "Ц":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_W);
                        break;
                    case "У":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_E);
                        break;
                    case "К":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_R);
                        break;
                    case "Е":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_T);
                        break;
                    case "Н":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_Y);
                        break;
                    case "Г":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_U);
                        break;
                    case "Ш":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_I);
                        break;
                    case "Щ":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_O);
                        break;
                    case "З":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_P);
                        break;
                    case "Ф":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_A);
                        break;
                    case "Ы":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_S);
                        break;
                    case "В":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_D);
                        break;
                    case "А":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_F);
                        break;
                    case "П":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_G);
                        break;
                    case "Р":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_H);
                        break;
                    case "О":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_J);
                        break;
                    case "Л":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_K);
                        break;
                    case "Д":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_L);
                        break;
                    case "Я":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_Z);
                        break;
                    case "Ч":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_X);
                        break;
                    case "С":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_C);
                        break;
                    case "М":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_V);
                        break;
                    case "И":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_B);
                        break;
                    case "Т":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_N);
                        break;
                    case "Ь":
                        settings.SaveBackgroundScreenKey(VIRTYUAL_KEY_KODES.VK_M);
                        break;
                    default:
                        MessageBox.Show("Невозможно задать данную клавишу.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}
