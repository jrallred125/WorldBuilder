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
    public class EditWeaponViewModel :ObservableObject
    {
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand OpenFileCommand { get; set; }

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
        private bool isNewCharacter { get; set; }

        public ItemsViewModel ItemsVM { get; set; }

        public EditWeaponViewModel(WeaponModel item, ItemsViewModel itemsVM, bool isNew)
        {
            SelectedItem = item;
            ItemsVM = itemsVM;
            isNewCharacter = isNew;

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

            SaveCommand = new RelayCommand(o =>
            {
                SelectedItem.Name = Name;
                SelectedItem.Image = Image;
                SelectedItem.Type = Type;
                SelectedItem.Value = Value;
                SelectedItem.Weight = Weight;
                SelectedItem.Description = Description;
                SelectedItem.Damage = Damage;
                SelectedItem.Properties = Properties;
                if (isNewCharacter)
                {
                    DataController.Instance.AddItem(SelectedItem);
                }
                ItemsVM.CurrentView = new ItemDetailsViewModel(SelectedItem, ItemsVM);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNewCharacter)
                {
                    itemsVM.CurrentView = null;
                    SelectedItem = null;
                }
                else
                {
                    ItemsVM.CurrentView = new ItemDetailsViewModel(SelectedItem, ItemsVM);
                }
            });

            OpenFileCommand = new RelayCommand(o =>
            {
                Image = new OpenFileDialogService().OpenFileDialog();
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
            set { 
                _properties = value;
                OnPropertyChanged();
            }
        }

    }
}
