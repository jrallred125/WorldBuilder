using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class ItemDetailsViewModel :ObservableObject
    {
       
        public RelayCommand EditItemCommand { get; set; }

        public RelayCommand DeleteItemCommand { get; set; }

        public RelayCommand ViewImageCommand { get; set; }


        public ItemDetailsViewModel(ItemModel item, ItemsViewModel itemsVm)
        {
            if (item != null)
            {
                Name = item.Name;
                Image = item.Image;
                Type = item.Type;
                Value = item.Value;
                Weight = item.Weight;
                Description = item.Description;
                Properties = item.Properties;
            }

            DeleteItemCommand = new RelayCommand(o =>
            {
                itemsVm.CurrentView = null;
                DataController.Instance.RemoveItem(item);
            });

            EditItemCommand = new RelayCommand(o =>
            {
                itemsVm.CurrentView = new EditItemViewModel(item, itemsVm, false);
            });

            ViewImageCommand = new RelayCommand(o =>
            {
                var imageWindow = new ImageWindow(new ImageViewModel(Image));
                imageWindow.Show();
            });

        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        private string _weight;

        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        private string _properties;
        public string Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                OnPropertyChanged();
            }
        }

    }
}
