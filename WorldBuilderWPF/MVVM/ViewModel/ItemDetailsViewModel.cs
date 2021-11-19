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
            SelectedItem = item;
            ItemsVM = itemsVm;
            if (SelectedItem != null)
            {
                Name = SelectedItem.Name;
                Image = SelectedItem.Image;
                Type = SelectedItem.Type;
                PlayerCost = SelectedItem.PlayerCost;
                PlayerSell = SelectedItem.PlayerSell;
                Discription = SelectedItem.Discription;
            }



            DeleteItemCommand = new RelayCommand(o =>
            {
                ItemsVM.CurrentView = null;
                DataController.Instance.RemoveItem(SelectedItem);
                SelectedItem = null;
            });

            EditItemCommand = new RelayCommand(o =>
            {
                ItemsVM.CurrentView = new EditItemViewModel(SelectedItem, ItemsVM, false);
            });

            ViewImageCommand = new RelayCommand(o =>
            {
                var imageWindow = new ImageWindow();
                imageWindow.Show();
            });

        }

        public ItemsViewModel ItemsVM { get; set; }


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
