using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class NewWorldViewModel : ObservableObject
    {
        public RelayCommand SaveWorldCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                OnPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public NewWorldViewModel(WorldModel world, HomeViewModel hmViewModel)
        {
            SaveWorldCommand = new RelayCommand(o => 
            {
                world.Name = Name;
                world.Description = Description;

                DataController.Instance.AddNewWorld(world);
                hmViewModel.CurrentView = new WorldViewModel();
            });

            CancelCommand = new RelayCommand(o => 
            {
                hmViewModel.CurrentView = null;
            });

        }
    }
}
