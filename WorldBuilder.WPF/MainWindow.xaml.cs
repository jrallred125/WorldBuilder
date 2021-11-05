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
using WorldBuilder.WPF.ViewModels;

namespace WorldBuilder.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Character A = new();
            A.Name = "Damaia Auburn Vanan";
            A.Age = 18;
            A.Race = "Tiefling";
            A.Height = "5 ft 4 in";
            A.Apparance = "She has red hair with purple streaks, green eyes and pink skin. She wears emerald earings and has one of her horns peirced.";
            A.AddTitle("Cap");
            A.AddTitle("Wicked Wine");

            A.AddImage("/Views/Auburn_front_green_eyes.png");
            A.SetProfileImage("/Views/Auburn_front_green_eyes.png");
            CharacterViewModel cm = new CharacterViewModel(A);
        }
       /* private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                BitmapImage x = new BitmapImage(fileUri);
                x.CacheOption = BitmapCacheOption.OnDemand;
                x.CreateOptions = BitmapCreateOptions.DelayCreation;
                //imgDynamic.Source = x;
            }
        }*/
    }
}
