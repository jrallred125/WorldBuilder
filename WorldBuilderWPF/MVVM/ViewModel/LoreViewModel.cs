using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class LoreViewModel : ObservableObject
    {
        /* Commands */
        public RelayCommand SearchCommand { get; set; }

        public RelayCommand NewLoreCommand { get; set; }
        
        private ObservableCollection<LoreModel> _lore;

        public ObservableCollection<LoreModel> Lore
        {
            get { return _lore; }
            set
            {
                _lore = value;
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
            }
        }

        private LoreModel _selectedLore;
        public LoreModel SelectedLore
        {
            get { return _selectedLore; }
            set
            {
                _selectedLore = value;
                OnPropertyChanged();
                if (_selectedLore != null)
                {
                    OpenLoreDetails();
                }
            }
        }

        private void OpenLoreDetails()
        {
            CurrentView = new LoreDetailsViewModel(SelectedLore, this);
        }
        public LoreViewModel()
        {
            Lore = DataController.Instance.Lore;

            SearchCommand = new RelayCommand(o =>
            {
                Lore = DataController.Instance.SearchLore(SearchProp);
            });

            NewLoreCommand = new RelayCommand(o =>
            {
                CurrentView = new EditLoreViewModel(new LoreModel(), this, true);
            });
        }

    }
}
