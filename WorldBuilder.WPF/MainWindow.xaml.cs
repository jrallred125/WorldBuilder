using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorldBuilder.Domain.Models;

namespace WorldBuilder.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Character A;
        public MainWindow()
        {
            InitializeComponent();

            A = new Character("Damaia Vanan", "Witchy.", "Pinked skinned, Auburn hair.");
        }
        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                BitmapImage x = new BitmapImage(fileUri);
                imgDynamic.Source = x;
                A.AddImage(x);

            }
        }
        private void BtnLoadFromResource_Click(object sender, RoutedEventArgs e)
        {
            imgDynamic.Source = A.Gallery.Current();
        }

        private void BtnNextImage_Click(object sender, RoutedEventArgs e)
        {
            imgDynamic.Source = A.Gallery.Next();
        }

        private void BtnPrevImage_Click(object sender, RoutedEventArgs e)
        {
           
            imgDynamic.Source = A.Gallery.Prev();
        }

        private void BtnRemoveImage_Click(object sender, RoutedEventArgs e)
        {
            A.RemoveImage((BitmapImage)imgDynamic.Source);
            imgDynamic.Source = A.Gallery.Prev();
        }
    }
}
