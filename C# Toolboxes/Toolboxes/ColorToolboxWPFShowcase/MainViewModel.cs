using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ColorToolboxWPFShowcase
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Reset();
        }

        public void ApplyContrast()
        {
            Colors = ColorToolbox.ColorToolbox.Contrast(Colors, (int)ProcessValue);
        }

        public void ApplyBrightness()
        {
            Colors = ColorToolbox.ColorToolbox.Brightness(Colors, (int)ProcessValue);
        }

        public async void ApplyBlur()
        {
            Color[,] colors = null;
            await Task.Run(() => colors = ColorToolbox.ColorToolbox.SimpleBlur(Colors, (int) ProcessValue));
            Colors = colors;
        }
        public void ApplyGammaCorrection()
        {
            Colors = ColorToolbox.ColorToolbox.GammaCorrect(Colors, ProcessValue);
        }

        public void ApplyInvert()
        {
            Colors = ColorToolbox.ColorToolbox.Invert(Colors);
        }

        public void ApplySaturation()
        {
            Colors = ColorToolbox.ColorToolbox.Saturation(Colors, ProcessValue);
        }

        public void Reset()
        {
            Colors = new Color[100, 100];

            for (int i = 0; i < 100; i++)
                for (int j = 0; j < 100; j++)
                    Colors[i, j] = Color.FromArgb(255, i, j, i + j);
            for (int i = 45; i < 55; i++)
                for (int j = 0; j < 100; j++)
                    Colors[i, j] = Color.FromArgb(255, 255, 0, 0);

            Colors = Colors;
        }


        private Color[,] _colors;
        private Color[,] Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                Bitmap bitmap = new Bitmap(100, 100);
                for (int i = 0; i < 100; i++)
                    for (int j = 0; j < 100; j++)
                        bitmap.SetPixel(i, j, _colors[i, j]);
                Bitmap = BitmapToImageSource(bitmap);
            }
        }

        private double _processValue;
        public double ProcessValue
        {
            get { return _processValue; }
            set
            {
                _processValue = value;
                NotifyPropertyChanged("ProcessValue");
            }
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private BitmapImage _bitmap;
        public BitmapImage Bitmap
        {
            get { return _bitmap; }
            set
            {
                _bitmap = value;
                NotifyPropertyChanged("Bitmap");
            }
        }


        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sends a notification to listeners/binders that the property with name of the parameter.
        /// If an empty string is provided in the parameter, all bindings to the datacontext will be updated.
        /// </summary>
        /// <param name="info">The name of the property which has been updated.</param>
        public void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}
