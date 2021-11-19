using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class EditItemViewModel : ObservableObject
    {
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }


        private ItemModel _selectedItem;

        public ItemModel SelectedItem
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

        public EditItemViewModel(ItemModel item, ItemsViewModel itemsVM, bool isNew)
        {
            SelectedItem = item;
            ItemsVM = itemsVM;
            isNewCharacter = isNew;

            if (SelectedItem != null)
            {
                Name = SelectedItem.Name;
                Image = SelectedItem.Image;
                Type = SelectedItem.Type;
                PlayerCost = SelectedItem.PlayerCost;
                PlayerSell = SelectedItem.PlayerSell;
                Discription = SelectedItem.Discription;
            }

            SaveCommand = new RelayCommand(o =>
            {
                SelectedItem.Name = Name;
                SelectedItem.Image = Image;
                SelectedItem.Type = Type;
                SelectedItem.PlayerCost = PlayerCost;
                SelectedItem.PlayerSell = PlayerSell;
                SelectedItem.Discription = Discription;
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

        private string _playerCost;

        public string PlayerCost
        {
            get { return _playerCost; }
            set
            {
                _playerCost = value;
                OnPropertyChanged();
            }
        }

        private string _playerSell;

        public string PlayerSell
        {
            get { return _playerSell; }
            set
            {
                _playerSell = value;
                OnPropertyChanged();
            }
        }

        private string _discription;

        public string Discription
        {
            get { return _discription; }
            set
            {
                _discription = value;
                OnPropertyChanged();
            }
        }
    }
}
