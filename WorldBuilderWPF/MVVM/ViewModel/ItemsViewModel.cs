﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class ItemsViewModel : ObservableObject
    {
        public List<string> Types { get; set; } = new List<string> { "Weapon", "Armor", "Adventuring Gear", "Magic Item" };

        private ObservableCollection<ItemModel> _items;

        public ObservableCollection<ItemModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SearchCommand { get; set; }

        public RelayCommand NewItemCommand { get; set; }

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

        private string _typeOfItem = "";
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
                default:
                    CurrentView = new ItemDetailsViewModel(SelectedItem, this);
                    break;
            }
        }

        public ItemsViewModel()
        {
            Types.Sort();
            Items = DataController.Instance.SearchItems(SearchProp);

            SearchCommand = new RelayCommand(o =>
            {
                Items = DataController.Instance.SearchItems(SearchProp);
            });

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
                    default:
                        ItemModel item = new ItemModel(TypeOfItem);
                        CurrentView = new EditItemViewModel(item, this, true);
                        break;
                }
                
            });

        }
    }
}
