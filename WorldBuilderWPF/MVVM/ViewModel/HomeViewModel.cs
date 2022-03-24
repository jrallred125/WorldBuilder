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
    public class HomeViewModel: ObservableObject
    {
        public RelayCommand NewWorldCommand { get; set; }

        public RelayCommand DeleteWorldCommand { get; set; }

        private string _selectedWorld;

        public string SelectedWorld
        {
            get { return _selectedWorld; }
            set { 
                _selectedWorld = value;
                OnPropertyChanged();
                DataController.Instance.SwapWorlds(value);
                CurrentView =  new WorldViewModel(this);
            }
        }

        public ObservableCollectionEx<string> Worlds
        {
            get { return DataController.Instance.Worlds; }
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


        public HomeViewModel()
        {
            NewWorldCommand = new RelayCommand(o =>
            {
                CurrentView = new EditWorldViewModel(new WorldModel(), this, true);
            });

            DeleteWorldCommand = new RelayCommand(o => 
            {
                DataController.Instance.DeleteWorld();
                SelectedWorld = "";
                CurrentView = null;
            });
        }

        public void UpdateSplashPage()
        {
            if (Worlds.Count == 0)
            {
                CurrentView = new EditWorldViewModel(new WorldModel(), this, true);
            }
            else CurrentView = new WorldViewModel(this);
        }




    }
}
