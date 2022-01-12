using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class LoresViewModel : ObservableObject
    {
        /* Commands */

        public RelayCommand NewLoreCommand { get; set; }

        public RelayCommand ImportLoreCommand { get; set; }

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
                Search();
      
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
        public LoresViewModel()
        {
            NewLoreCommand = new RelayCommand(o =>
            {
                CurrentView = new EditLoreViewModel(new LoreModel(), this, true);
            });

            ImportLoreCommand = new RelayCommand(o => 
            {
                string file = new FileDialogService().OpenFileDialogJson();
                DataController.Instance.ImportLores(file);
            });
        }

        internal void Update()
        {
            Lore = DataController.Instance.SearchLores(SearchProp);
        }

        private void Search()
        {
            Lore = DataController.Instance.SearchLores(SearchProp);
        }

    }
}
