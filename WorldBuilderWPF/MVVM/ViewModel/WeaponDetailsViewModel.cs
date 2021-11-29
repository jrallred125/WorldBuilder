using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class WeaponDetailsViewModel :ObservableObject
    {
        public RelayCommand EditItemCommand { get; set; }

        public RelayCommand DeleteItemCommand { get; set; }

        public RelayCommand ViewImageCommand { get; set; }


        public WeaponDetailsViewModel(WeaponModel item, ItemsViewModel itemsVm)
        {
            SelectedItem = item;
            ItemsVM = itemsVm;
            if (SelectedItem != null)
            {
                Name = SelectedItem.Name;
                Image = SelectedItem.Image;
                Type = SelectedItem.Type;
                Value = SelectedItem.Value;
                Weight = SelectedItem.Weight;
                Description = SelectedItem.Description;
                Damage = SelectedItem.Damage;
                Properties = SelectedItem.Properties;
            }



            DeleteItemCommand = new RelayCommand(o =>
            {
                ItemsVM.CurrentView = null;
                DataController.Instance.RemoveItem(SelectedItem);
                SelectedItem = null;
            });

            EditItemCommand = new RelayCommand(o =>
            {
                ItemsVM.CurrentView = new EditWeaponViewModel(SelectedItem, ItemsVM, false);
            });

            ViewImageCommand = new RelayCommand(o =>
            {
                var imageWindow = new ImageWindow(new ImageViewModel(Image));
                imageWindow.Show();
            });

        }

        public ItemsViewModel ItemsVM { get; set; }


        private WeaponModel _selectedItem;

        public WeaponModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
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

        private string _damage;

        public string Damage
        {
            get { return _damage; }
            set
            {
                _damage = value;
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
