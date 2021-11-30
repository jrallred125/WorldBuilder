using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class MagicItemDetailsViewModel : ObservableObject
    {
        public RelayCommand EditItemCommand { get; set; }

        public RelayCommand DeleteItemCommand { get; set; }

        public RelayCommand ViewImageCommand { get; set; }


        public MagicItemDetailsViewModel(MagicItemModel item, ItemsViewModel itemsVm)
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
                Properties = SelectedItem.Properties;
                Rarity = SelectedItem.Rarity;
                Bonus = SelectedItem.Bonus;
                IsCursed = SelectedItem.IsCursed;
            }



            DeleteItemCommand = new RelayCommand(o =>
            {
                ItemsVM.CurrentView = null;
                DataController.Instance.RemoveItem(SelectedItem);
                SelectedItem = null;
            });

            EditItemCommand = new RelayCommand(o =>
            {
                ItemsVM.CurrentView = new EditMagicItemViewModel(SelectedItem, ItemsVM, false);
            });

            ViewImageCommand = new RelayCommand(o =>
            {
                var imageWindow = new ImageWindow(new ImageViewModel(Image));
                imageWindow.Show();
            });

        }

        public ItemsViewModel ItemsVM { get; set; }


        private MagicItemModel _selectedItem;

        public MagicItemModel SelectedItem
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

        private string _rarity;
        public string Rarity
        {
            get { return _rarity; }
            set
            {
                _rarity = value;
                OnPropertyChanged();
            }
        }

        private string _bonus;
        public string Bonus
        {
            get { return _bonus; }
            set
            {
                _bonus = value;
                OnPropertyChanged();
            }
        }

        private bool _isCursed;
        public bool IsCursed
        {
            get { return _isCursed; }
            set
            {
                _isCursed = value;
                OnPropertyChanged();
            }
        }
    }
}
