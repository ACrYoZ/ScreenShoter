using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using upScreenLib;

namespace ScreenShoter.Classes
{
    class CaptureControl
    {
        // Экран к которому мы обращаемся для захвата (дополнительно) по умолчанию к первому экрану
        public static Screen CaptureScreen = Screen.PrimaryScreen;

        //Инициализируем настройки
        public static Settings settings;

        // Список файлов подходящих под аргументы
        public static List<string> ArgFiles = new List<string>();

        // Все картинки сохраненные в сессии
        public static List<Image> CapturedImages = new List<Image>();

        // Скрин всего экрана
        private static Bitmap FullScreen;

        #region Обработка снимков экрана

        public static void CaptFullScreen()
        {
            GetBackgroundImage();

            SaveAndOpenImage(FullScreen);
        }

        public static void CaptFromClipboard()
        {
            System.Drawing.Image image;

            //Вставить картинку из буфера обмена
            if (Clipboard.ContainsImage())
            {
                image = Clipboard.GetImage();
                SaveAndOpenImage(image);
            }

            //Если это был скопированный файл картинки - тогда загружаем его
            else if (Clipboard.ContainsFileDropList())
            {
                foreach(var file in Clipboard.GetFileDropList())
                {
                    SaveAndOpenImage(file);
                }
            }
        }

        public static void CaptFromArea(Bitmap bitmap)
        {
            SaveAndOpenImage(bitmap);
        }

        public static void CaptBackground(int Width, int Height, int X, int Y)
        {

            Rectangle screenBounds = new Rectangle(X, Y, Width, Height);
            Bitmap screenshot = new Bitmap(screenBounds.Width, screenBounds.Height, PixelFormat.Format32bppArgb);
            Graphics screenGraph = Graphics.FromImage(screenshot);
            screenGraph.CopyFromScreen(screenBounds.X, screenBounds.Y, 0, 0, screenBounds.Size, CopyPixelOperation.SourceCopy);
            System.Drawing.Image img = (System.Drawing.Image)screenshot;
            SaveAndOpenImage(img);

        }
        #endregion
        
        /// <summary>
        /// Методы для сохранения и открытия скрина
        /// </summary>
        /// <param name="Image image"></param>
        /// Метод с параметром Image image, конвертирует из Image в Graphics, затем сохраняет и
        /// открывает файл
        /// 
        /// <param name="Bitmap image"></param>
        /// Метод с параметром Bitmap image сразу сохраняет и открывает файл
        /// 
        /// <param name="string path"></param>
        /// В path передается путь к файлу скопированной картинки, после чего этот файл
        /// грубо говоря копируется под другим именем в папку со скриншотами
        private static void SaveAndOpenImage(System.Drawing.Image image)
        {
            settings = new Settings();

            var gfx = Graphics.FromImage(image);

            //Генерируем имя
            var captureName = Common.RandomString(settings.fileNameLength) + Common.GetFormat();

            //Создаем объект с информацией о файле (имя и путь)
            var info = new Image
            {
                Name = captureName,
                LocalPath = settings.fileSavePath + "\\" + captureName
            };

            image.Save(info.LocalPath);
            CapturedImages.Add(info);

            //Открываем сохраненный скрин
            Process.Start(info.LocalPath);
        }
        private static void SaveAndOpenImage(Bitmap image)
        {
            settings = new Settings();

            //Генерируем имя
            var captureName = Common.RandomString(settings.fileNameLength) + Common.GetFormat();

            //Создаем объект с информацией о файле (имя и путь)
            var info = new Image
            {
                Name = captureName,
                LocalPath = settings.fileSavePath + "\\" + captureName
            };

            image.Save(info.LocalPath);
            CapturedImages.Add(info);

            //Открываем сохраненный скрин
            Process.Start(info.LocalPath);
        }
        private static void SaveAndOpenImage(string path)
        {
            settings = new Settings();

            var image = System.Drawing.Image.FromFile(path);
            var captureName = Common.RandomString(settings.fileNameLength) + Common.GetFormat(image.RawFormat);

            var info = new Image()
            {
                Name = captureName,
                LocalPath = "\"" + settings.fileSavePath + "\\" + captureName
            };

            image.Save(info.LocalPath);
            CapturedImages.Add(info);

            //Открываем сохраненный скрин
            Process.Start(info.LocalPath);
        }

        public static void GetBackgroundImage()
        {
            var bmp = new Bitmap(CaptureScreen.Bounds.Width, CaptureScreen.Bounds.Height);
            var gfx = Graphics.FromImage(bmp);
            gfx.CopyFromScreen(CaptureScreen.Bounds.X, CaptureScreen.Bounds.Y, 0, 0, CaptureScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            FullScreen = bmp;
        }
    }
}
