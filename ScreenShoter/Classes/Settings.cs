using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenShoter.Classes
{
    class Settings
    {
        #region Константы ключей и секций

        public const string INI_FILE_SETTINGS_SECTION = "FileSettings";
        public const string INI_F_PATH_NAME_KEY = "Path";
        public const string INI_F_NAME_LENGTH_KEY = "NameLentgth";

        public const string INI_KEYS_SECTION = "Key";
        public const string INI_GLOBAL_SCREEN_KEY = "GlobalScreen";
        public const string INI_AREA_SCREEN_KEY = "AreaScreen";
        public const string INI_CLIPBOARD_SCREEN_KEY = "ClipboardScreen";
        public const string INI_BACKGROUND_SCREEN_KEY = "BackgroundWindow";

        public const string INI_CTRL_GLOBAL_KEY = "CtrlGlobal";
        public const string INI_CTRL_AREA_KEY = "CtrlArea";
        public const string INI_CTRL_CLIPBOARD_KEY = "CtrlClipboard";
        public const string INI_CTRL_BACKGROUND_KEY = "CtrlBackground";

        #endregion

        IniFile ini = new IniFile(@"config.ini");

        public string fileSavePath;
        public int fileNameLength;

        public byte globalScreenKey = VIRTYUAL_KEY_KODES.VK_F5;
        public bool ctrlForGlobal;

        public byte areaScreenKey = VIRTYUAL_KEY_KODES.VK_F6;
        public bool ctrlForArea;

        public byte clipboardScreenKey = VIRTYUAL_KEY_KODES.VK_F7;
        public bool ctrlForClipboard;

        public byte backgroundScreenKey = VIRTYUAL_KEY_KODES.VK_F8;
        public bool ctrlForBackground;
        

        public Settings() { Load(); }

        #region Методы сохранения файла настроек

        public void SaveFilePath(string file_path)
        {
            ini.Write(INI_FILE_SETTINGS_SECTION, INI_F_PATH_NAME_KEY, file_path);
        }

        public void SaveFileLength(int f_length)
        {
            ini.Write(INI_FILE_SETTINGS_SECTION, INI_F_NAME_LENGTH_KEY, f_length.ToString());
        }

        public void SaveGlobalScrKey(byte virtual_key_id)
        {
            ini.Write(INI_KEYS_SECTION, INI_GLOBAL_SCREEN_KEY, virtual_key_id.ToString());
        }

        public void SaveAreaScrKey(byte virtual_key_id)
        {
            ini.Write(INI_KEYS_SECTION, INI_AREA_SCREEN_KEY, virtual_key_id.ToString());
        }

        public void SaveClipScreenKey(byte virtual_key_id)
        {
            ini.Write(INI_KEYS_SECTION, INI_CLIPBOARD_SCREEN_KEY, virtual_key_id.ToString());
        }

        public void SaveBackgroundScreenKey(byte virtual_key_id)
        {
            ini.Write(INI_KEYS_SECTION, INI_BACKGROUND_SCREEN_KEY, virtual_key_id.ToString());
        }

        public void SaveCtrlForGlobal(bool mode)
        {
            ini.Write(INI_KEYS_SECTION, INI_CTRL_GLOBAL_KEY, mode.ToString());
        }

        public void SaveCtrlForArea(bool mode)
        {
            ini.Write(INI_KEYS_SECTION, INI_CTRL_AREA_KEY, mode.ToString());
        }

        public void SaveCtrlForClip(bool mode)
        {
            ini.Write(INI_KEYS_SECTION, INI_CTRL_CLIPBOARD_KEY, mode.ToString());
        }

        public void SaveCtrlForBackground(bool mode)
        {
            ini.Write(INI_KEYS_SECTION, INI_CTRL_BACKGROUND_KEY, mode.ToString());
        }

        #endregion

        //Метод загрузки настроек
        public void Load()
        {
            if (ini.KeyExists(INI_F_PATH_NAME_KEY))
            {
                fileSavePath = ini.ReadINI(INI_FILE_SETTINGS_SECTION, INI_F_PATH_NAME_KEY);
            }
            else
            {
                fileSavePath = "";
            }

            if (ini.KeyExists(INI_F_NAME_LENGTH_KEY))
            {
                int.TryParse(ini.ReadINI(INI_FILE_SETTINGS_SECTION, INI_F_NAME_LENGTH_KEY), out fileNameLength);
            }
            else
            {
                ini.Write(INI_FILE_SETTINGS_SECTION, INI_F_NAME_LENGTH_KEY, "5");
                fileNameLength = 5;
            }

            if (ini.KeyExists(INI_GLOBAL_SCREEN_KEY))
            {
                byte.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_GLOBAL_SCREEN_KEY), out globalScreenKey);
                if(globalScreenKey == 0)
                {
                    globalScreenKey = VIRTYUAL_KEY_KODES.VK_F5;
                }
            }
            else
            {
                ini.Write(INI_KEYS_SECTION, INI_GLOBAL_SCREEN_KEY, VIRTYUAL_KEY_KODES.VK_F5.ToString());
                globalScreenKey = VIRTYUAL_KEY_KODES.VK_F5;
            }

            if (ini.KeyExists(INI_CLIPBOARD_SCREEN_KEY))
            {
                byte.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_CLIPBOARD_SCREEN_KEY), out clipboardScreenKey);
                if (clipboardScreenKey == 0)
                {
                    clipboardScreenKey = VIRTYUAL_KEY_KODES.VK_F6;
                }
            }
            else
            {
                ini.Write(INI_KEYS_SECTION, INI_CLIPBOARD_SCREEN_KEY, VIRTYUAL_KEY_KODES.VK_F6.ToString());
                clipboardScreenKey = VIRTYUAL_KEY_KODES.VK_F6;
            }

            if (ini.KeyExists(INI_AREA_SCREEN_KEY))
            {
                byte.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_AREA_SCREEN_KEY), out areaScreenKey);
                if (areaScreenKey == 0)
                {
                    areaScreenKey = VIRTYUAL_KEY_KODES.VK_F7;
                }
            }
            else
            {
                ini.Write(INI_KEYS_SECTION, INI_AREA_SCREEN_KEY, VIRTYUAL_KEY_KODES.VK_F7.ToString());
                areaScreenKey = VIRTYUAL_KEY_KODES.VK_F7;
            }

            if (ini.KeyExists(INI_BACKGROUND_SCREEN_KEY))
            {
                byte.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_BACKGROUND_SCREEN_KEY), out backgroundScreenKey);
                if (backgroundScreenKey == 0)
                {
                    backgroundScreenKey = VIRTYUAL_KEY_KODES.VK_F8;
                }
            }
            else
            {
                ini.Write(INI_KEYS_SECTION, INI_BACKGROUND_SCREEN_KEY, VIRTYUAL_KEY_KODES.VK_F8.ToString());
                backgroundScreenKey = VIRTYUAL_KEY_KODES.VK_F8;

            }

            if (ini.KeyExists(INI_CTRL_GLOBAL_KEY))
            {
                bool.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_CTRL_GLOBAL_KEY), out ctrlForGlobal);
            }
            else
            {
                ctrlForGlobal = false;
            }

            if (ini.KeyExists(INI_CTRL_CLIPBOARD_KEY))
            {
                bool.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_CTRL_CLIPBOARD_KEY), out ctrlForClipboard);
            }
            else
            {
                ctrlForClipboard = false;
            }

            if (ini.KeyExists(INI_CTRL_AREA_KEY))
            {
                bool.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_CTRL_AREA_KEY), out ctrlForArea);
            }
            else
            {
                ctrlForArea = false;
            }

            if (ini.KeyExists(INI_CTRL_BACKGROUND_KEY))
            {
                bool.TryParse(ini.ReadINI(INI_KEYS_SECTION, INI_CTRL_BACKGROUND_KEY), out ctrlForBackground);
            }
            else
            {
                ctrlForBackground = false;
            }
        }
    }

    //http://vsokovikov.narod.ru/New_MSDN_API/Other/virtual_key_code.htm - коды виртуальных клавиш.

    public static class VIRTYUAL_KEY_KODES
    {
        public static readonly byte VK_CONTROL = 0xA2;
        public static readonly byte VK_A = 0x41;
        public static readonly byte VK_B = 0x42;
        public static readonly byte VK_C = 0x43;
        public static readonly byte VK_D = 0x44;
        public static readonly byte VK_E = 0x45;
        public static readonly byte VK_F = 0x46;
        public static readonly byte VK_G = 0x47;
        public static readonly byte VK_H = 0x48;
        public static readonly byte VK_I = 0x49;
        public static readonly byte VK_J = 0x4A;
        public static readonly byte VK_K = 0x4B;
        public static readonly byte VK_L = 0x4C;
        public static readonly byte VK_M = 0x4D;
        public static readonly byte VK_N = 0x4E;
        public static readonly byte VK_O = 0x4F;
        public static readonly byte VK_P = 0x50;
        public static readonly byte VK_Q = 0x51;
        public static readonly byte VK_R = 0x52;
        public static readonly byte VK_S = 0x53;
        public static readonly byte VK_T = 0x54;
        public static readonly byte VK_U = 0x55;
        public static readonly byte VK_V = 0x56;
        public static readonly byte VK_W = 0x57;
        public static readonly byte VK_X = 0x58;
        public static readonly byte VK_Y = 0x59;
        public static readonly byte VK_Z = 0x5A;
        public static readonly byte VK_F1 = 0x70;
        public static readonly byte VK_F2 = 0x71;
        public static readonly byte VK_F3 = 0x72;
        public static readonly byte VK_F4 = 0x73;
        public static readonly byte VK_F5 = 0x74;
        public static readonly byte VK_F6 = 0x75;
        public static readonly byte VK_F7 = 0x76;
        public static readonly byte VK_F8 = 0x77;
        public static readonly byte VK_F9 = 0x78;
        public static readonly byte VK_F10 = 0x79;
        public static readonly byte VK_F11 = 0x7A;
        public static readonly byte VK_F12 = 0x7B;
    }
}
