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
        public RelayCommand  HomeViewCommand { get; set; }

        public RelayCommand CharactersViewCommand { get; set; }
        public HomeViewModel HomeVm { get; set; }

        public CharactersViewModel CharactersVm { get; set; }
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
            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o => 
            {
                CurrentView = HomeVm;
            });

            CharactersViewCommand = new RelayCommand(o =>
            {
                CurrentView = CharactersVm;
            });
        }
    }
}
