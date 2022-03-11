using Microsoft.Win32;
using System;
using System.Drawing;
using System.Windows;
//using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ConvertBinary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "D:\\wallpaper\\wallpaper";
            ofd.Filter = "Jpg files (*.jpg)|*.jpg|Png files (*.png)|*.png";
            if (ofd.ShowDialog() == true)
            {
                string path = ofd.FileName;
                BitmapImage bitmapImage = new BitmapImage(new Uri(path));
                imageOriginal.Source = bitmapImage;

                Bitmap btm = new Bitmap(path);

                int height = btm.Height;
                int width = btm.Width;

                Color p;

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        p = btm.GetPixel(i, j);
                        int a = p.A;
                        int r = p.R;
                        int g = p.G;
                        int b = p.B;

                        int avg = (r + g + b) / 3;
                        
                        int toSet ;

                        if (avg > 128 )
                        {
                            toSet = 255;
                        }
                        else
                        {
                            toSet = 0;
                        }

                        btm.SetPixel(i, j, Color.FromArgb(a, toSet, toSet, toSet));
                    }
                }
                string pathToSave = System.AppDomain.CurrentDomain.BaseDirectory + "\\binary.png";
                btm.Save(pathToSave);
                imageBinary.Source = new BitmapImage(new Uri(pathToSave));
            }
        }
    }
}
