using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class ImageViewModel : ObservableObject
    {

        private string _image;

        public string Image
        {
            get { return _image; }
            set { 
                _image = value;
                OnPropertyChanged();
            }
        }

        public ImageViewModel(string image)
        {
            Image = image;
        }

    }
}
