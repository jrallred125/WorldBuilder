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
    public class CharactersViewModel : ObservableObject
    {
        public ObservableCollection<CharacterModel> Characters { get; set; }

       public RelayCommand SearchCommand { get; set; }


        private CharacterModel _selectedCharacter;

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

        public CharacterModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged();
                OpenCharacterDetails();
            }
        }

        private void OpenCharacterDetails()
        {
            CurrentView = new CharacterDetailsViewModel(SelectedCharacter, this);
        }

        public CharactersViewModel()
        {
            Characters = new ObservableCollection<CharacterModel>();

            SearchCommand = new RelayCommand(o =>
            {
                // Todo 
            });


            Characters.Add(new CharacterModel
            {
                Name = "Damaia Auburn Vanan",
                Race = "Tiefling",
                Age = 18,
                Height = "5 ft 4 in",
                Weight = "104 lbs",
                Gender = "Female",
                Apparance = "Pink skin with green eyes. Auburn hair with purple streaks.",
                Personality = "Bitchy, but nice.",
                Likes = "Lewd jokes.",
                Dislikes = "Cats",
                Backstory = "Her parents divorced at when she was 6 years old. Her mother made her work in the shop all day. She left to live with her father at the age of 15.",
                ProfileImage = "https://www.worldanvil.com/uploads/images/2a33e079cd1aac298104a430f49d0154.png"

            });

            Characters.Add(new CharacterModel
            {
                Name = "Resai Jewel",
                Race = "1/2 human 1/2 Tabaxi",
                Age = 18,
                Height = "6 ft 3 in",
                Weight = "124 lbs",
                Gender = "Female",
                Apparance = "Mostly human. She had purple hair that fades to blue at the ends. She has cat ears and a tail that are purple. She also has green cat eyes.",
                Personality = "Quite, but nice.",
                Likes = "Fish.",
                Dislikes = "Dogs.",
                Backstory = "None yet.",
                ProfileImage = "https://www.worldanvil.com/uploads/images/03c70ad3f35460df1f08bb2c5f00d784.png"
            });
        }
    }
}
