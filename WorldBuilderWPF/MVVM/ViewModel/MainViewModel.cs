using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand CharactersViewCommand { get; set; }

        public RelayCommand ItemsViewCommand { get; set; }

        public RelayCommand LocationsViewCommand { get; set; }

        public RelayCommand LoreViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }

        public CharactersViewModel CharactersVm { get; set; }

        public ItemsViewModel ItemsVm { get; set; }

        public LocationsViewModel LocationsVm { get; set; }

        public LoresViewModel LoresVm { get; set; }


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



        public MainViewModel()
        {
            HomeVm = new HomeViewModel();
            CharactersVm = new CharactersViewModel();
            ItemsVm = new ItemsViewModel();
            LocationsVm = new LocationsViewModel();
            LoresVm = new LoresViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o => 
            {
                HomeVm.UpdateSplashPage();
                CurrentView = HomeVm;
            });

            CharactersViewCommand = new RelayCommand(o =>
            {
                CurrentView = CharactersVm;
                CharactersVm.Update();
            });

            ItemsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ItemsVm;
                ItemsVm.Update();
            });

            LoreViewCommand = new RelayCommand(o =>
            {
                CurrentView = LoresVm;
                LoresVm.Update();
            });

            LocationsViewCommand = new RelayCommand(o =>
            {
                CurrentView = LocationsVm;
                LocationsVm.Update();
            });

        }
    }
}
