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
    public class EditMagicItemViewModel : ObservableObject
    {
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public RelayCommand OpenFileCommand { get; set; }
        public EditMagicItemViewModel(MagicItemModel selectedItem, ItemsViewModel itemsVm, bool isNew)
        {
            SelectedItem = selectedItem;
            ItemsVM = itemsVm;
            IsNew = isNew;
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

            SaveCommand = new RelayCommand(o =>
            {
                SelectedItem.Name = Name;
                SelectedItem.Image = Image;
                SelectedItem.Type = Type;
                SelectedItem.Value = Value;
                SelectedItem.Weight = Weight;
                SelectedItem.Description = Description;
                SelectedItem.Properties = Properties;
                SelectedItem.Rarity = Rarity;
                SelectedItem.Bonus = Bonus;
                SelectedItem.IsCursed = IsCursed;
                if (IsNew)
                {
                    DataController.Instance.AddItem(SelectedItem);
                }
                ItemsVM.CurrentView = new MagicItemDetailsViewModel(SelectedItem, ItemsVM);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (IsNew)
                {
                    ItemsVM.CurrentView = null;
                    SelectedItem = null;
                }
                else
                {
                    ItemsVM.CurrentView = new MagicItemDetailsViewModel(SelectedItem, ItemsVM);
                }
            });

            OpenFileCommand = new RelayCommand(o =>
            {
                Image = new OpenFileDialogService().OpenFileDialog();
            });
        }
        public ItemsViewModel ItemsVM { get; set; }

        private bool IsNew { get; set; }

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
