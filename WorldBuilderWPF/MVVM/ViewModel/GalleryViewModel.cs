using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class GalleryViewModel : ObservableObject
    {
        public RelayCommand OpenFileCommand { get; set; }

        public RelayCommand AddIamgeCommand { get; set; }
        public GalleryViewModel(GalleryModel gallery)
        {
            Gallery = gallery;

            OpenFileCommand = new RelayCommand(o =>
            {
                NewImage = new OpenFileDialogService().OpenFileDialog();
            });

            AddIamgeCommand = new RelayCommand(o =>
            {
                Gallery.AddIamge(NewImage);
                NewImage = "";
            });
        }

        private GalleryModel _gallery;

        public GalleryModel Gallery
        {
            get { return _gallery; }
            set { 
                _gallery = value;
                OnPropertyChanged();
            }
        }

        private string _newImage ="";

        public string NewImage
        {
            get { return _newImage; }
            set {
                _newImage = value;
                OnPropertyChanged();
            }
        }





    }
}
