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
    public class EditWorldViewModel : ObservableObject
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

        private ObservableCollectionEx<NameAndBool> _typesOfItems;

        public ObservableCollectionEx<NameAndBool> TypesOfItems
        {
            get { return _typesOfItems; }
            set { _typesOfItems = value; }
        }


        public EditWorldViewModel(WorldModel world, HomeViewModel hmViewModel, bool newworld)
        {
            Name = world.Name;
            Description = world.Description;
            TypesOfItems = world.TypesOfItems;

            SaveWorldCommand = new RelayCommand(o => 
            {
                world.Name = Name;
                world.Description = Description;
                world.TypesOfItems = TypesOfItems;

                if (newworld)
                {
                    DataController.Instance.AddNewWorld(world);
                }
                
                hmViewModel.CurrentView = new WorldViewModel();

            });

            CancelCommand = new RelayCommand(o => 
            {
                hmViewModel.CurrentView = null;
            });

        }

    }
}
