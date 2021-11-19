using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class CharacterDetailsViewModel : ObservableObject
    {
        public RelayCommand EditCharacterCommand { get; set; }

        public RelayCommand DeleteCharacterCommand { get; set; }

        public RelayCommand ViewImageCommand { get; set; }


        public CharacterDetailsViewModel(CharacterModel character, CharactersViewModel charactersViewModel)
        {
            SelectedCharacter = character;
            CharactersVM = charactersViewModel;
            if (SelectedCharacter != null)
            {
                Name = SelectedCharacter.Name;
                ProfileImage = SelectedCharacter.ProfileImage;
                Age = SelectedCharacter.Age;
                Weight = SelectedCharacter.Weight;
                Height = SelectedCharacter.Height;
                Gender = SelectedCharacter.Gender;
                Race = SelectedCharacter.Race;
                Personality = SelectedCharacter.Personality;
                Likes = SelectedCharacter.Likes;
                Dislikes = SelectedCharacter.Dislikes;
                Backstory = SelectedCharacter.Backstory;
                Apparance = SelectedCharacter.Apparance;
            }

            

            DeleteCharacterCommand = new RelayCommand(o =>
            {
                CharactersVM.CurrentView = null;
                DataController.Instance.RemoveCharacter(SelectedCharacter);
                SelectedCharacter = null;
            });

            EditCharacterCommand = new RelayCommand(o =>
            {
                CharactersVM.CurrentView = new EditCharacterViewModel(SelectedCharacter, CharactersVM, false);
            });

            ViewImageCommand = new RelayCommand(o => 
            {
                var imageWindow = new ImageWindow();
                imageWindow.Show();
            });

        }

        public CharactersViewModel CharactersVM{ get; set; }


        private CharacterModel _selectedCharacter;      

        public CharacterModel SelectedCharacter
        {
            get { return _selectedCharacter; }
            set
            {
                _selectedCharacter = value;
                OnPropertyChanged();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _profileImage;

        public string ProfileImage
        {
            get { return _profileImage; }
            set
            {
                _profileImage = value;
                OnPropertyChanged();
            }
        }

        private string _age;

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        private string _weight;

        public string Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        private string _height;

        public string Height
        {
            get { return _height; }
            set { 
                _height = value;
                OnPropertyChanged();
            }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set { 
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _race;

        public string Race
        {
            get { return _race; }
            set { 
                _race = value;
                OnPropertyChanged();
            }
        }

        private string _personality;

        public string Personality
        {
            get { return _personality; }
            set
            {
                _personality = value;
                OnPropertyChanged();
            }
        }

        private string _likes;

        public string Likes
        {
            get { return _likes; }
            set
            {
                _likes = value;
                OnPropertyChanged();
            }
        }
        private string _dislikes;

        public string Dislikes
        {
            get { return _dislikes; }
            set
            {
                _dislikes = value;
                OnPropertyChanged();
            }
        }

        private string _backstroy;

        public string Backstory
        {
            get { return _backstroy; }
            set
            {
                _backstroy = value;
                OnPropertyChanged();
            }
        }

        private string _apparance;

        public string Apparance
        {
            get { return _apparance; }
            set
            {
                _apparance = value;
                OnPropertyChanged();
            }
        }

    }
}
