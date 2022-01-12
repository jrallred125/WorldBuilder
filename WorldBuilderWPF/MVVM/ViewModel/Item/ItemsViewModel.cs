using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class ItemsViewModel : ObservableObject
    {        
        
        public RelayCommand NewItemCommand { get; set; }

        public RelayCommand ImportItemCommand { get; set; }
        public ItemsViewModel()
        {
            NewItemCommand = new RelayCommand(o =>
            {

                switch (TypeOfItem)
                {
                    case "Weapon":
                        WeaponModel weapon = new WeaponModel(TypeOfItem);
                        CurrentView = new EditWeaponViewModel(weapon, this, true);
                        break;
                    case "Armor":
                        ArmorModel armor = new ArmorModel(TypeOfItem);
                        CurrentView = new EditArmorViewModel(armor, this, true);
                        break;
                    case "Magic Item":
                        MagicItemModel magicItem = new MagicItemModel(TypeOfItem);
                        CurrentView = new EditMagicItemViewModel(magicItem, this, true);
                        break;
                    case "Magic Weapon":
                        MagicWeaponModel magicWeapon = new MagicWeaponModel(TypeOfItem);
                        CurrentView = new EditMagicWeaponViewModel(magicWeapon, this, true);
                        break;
                    case "Magic Armor":
                        MagicArmorModel magicArmor = new MagicArmorModel(TypeOfItem);
                        CurrentView = new EditMagicArmorViewModel(magicArmor, this, true);
                        break;
                    default:
                        ItemModel item = new ItemModel(TypeOfItem);
                        CurrentView = new EditItemViewModel(item, this, true);
                        break;
                }

            });

            ImportItemCommand = new RelayCommand(o => 
            {
                string file = new FileDialogService().OpenFileDialogJson();
                DataController.Instance.ImportItems(file);
            });

        }

        public void Update()
        {

            Types.Sort();
            Items = DataController.Instance.SearchItems(SearchProp);
        }

        private ObservableCollection<IItemModel> _items;

        public ObservableCollection<IItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        private string _searchProp;

        public string SearchProp
        {
            get { return _searchProp; }
            set
            {
                _searchProp = value;
                OnPropertyChanged();
                Search();
            }
        }
        
        private ItemModel _selectedItem;
        public ItemModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                if (_selectedItem != null)
                {
                    OpenItemDetails();
                }
            }
        }

        private string _typeOfItem = "Adventuring Gear";
        public string TypeOfItem
        {
            get { return _typeOfItem; }
            set
            { 
                _typeOfItem = value;
                OnPropertyChanged();
            }
        }

        private void OpenItemDetails()
        {
            switch (SelectedItem.Type)
            {
                case "Weapon":
                    CurrentView = new WeaponDetailsViewModel((WeaponModel)SelectedItem, this);
                    break;
                case "Armor":
                    CurrentView = new ArmorDetailsViewModel((ArmorModel)SelectedItem, this);
                    break;
                case "Magic Item":
                    CurrentView = new MagicItemDetailsViewModel((MagicItemModel)SelectedItem, this);
                    break;
                case "Magic Weapon":
                    CurrentView = new MagicWeaponDetailsViewModel((MagicWeaponModel)SelectedItem, this);
                    break;
                case "Magic Armor":
                    CurrentView = new MagicArmorDetailsViewModel((MagicArmorModel)SelectedItem, this);
                    break;
                default:
                    CurrentView = new ItemDetailsViewModel(SelectedItem, this);
                    break;
            }
        }

        private void Search()
        {
            Items = DataController.Instance.SearchItems(SearchProp);
        }

        public List<string> Types { get; set; } = new List<string> { "Weapon", "Armor", "Adventuring Gear", "Magic Item", "Magic Weapon", "Magic Armor" };
    }
}
