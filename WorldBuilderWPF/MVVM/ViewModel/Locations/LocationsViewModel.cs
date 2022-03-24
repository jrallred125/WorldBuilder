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
    public class LocationsViewModel : ObservableObject
    {
        private ObservableCollectionEx<ILocationModel> _locations;

        public ObservableCollectionEx<ILocationModel> Locations
        {
            get { return _locations; }
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NewLocationCommand { get; set; }

        public RelayCommand ImportLocationCommand { get; set; }

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

        private ILocationModel _selectedLocation;
        public ILocationModel SelectedLocation
        {
            get { return _selectedLocation; }
            set
            {
                _selectedLocation = value;
                OnPropertyChanged();
                if (_selectedLocation != null)
                {
                    OpenLocationDetails();
                }
            }
        }

        private void OpenLocationDetails()
        {
            //CurrentView = new CharacterDetailsViewModel(SelectedCharacter, this);
        }

        public LocationsViewModel()
        {
            NewLocationCommand = new RelayCommand(o =>
            {
                //CharacterModel character = new CharacterModel();
                //CurrentView = new EditCharacterViewModel(character, this, true);
            });

            ImportLocationCommand = new RelayCommand(o =>
            {
                string file = new FileDialogService().OpenFileDialogJson();
                DataController.Instance.ImportLocatons(file);
            });

        }
        private void Search()
        {
            Locations = DataController.Instance.SearchLocations(SearchProp);
        }

        public void Update()
        {
            Locations = DataController.Instance.SearchLocations(SearchProp);
        }
    }
}
