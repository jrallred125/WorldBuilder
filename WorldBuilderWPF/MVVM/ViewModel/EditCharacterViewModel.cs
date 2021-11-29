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
    public class EditCharacterViewModel : ObservableObject
    {
        /* Commands */
        public RelayCommand SaveCommand { get; set; }

        public RelayCommand CancelCommand { get; set; }

        public RelayCommand OpenFileCommand { get; set; }


        private CharacterModel _character;

        public CharacterModel SelectedCharacter
        {
            get { return _character; }
            set { 
                _character = value;
                OnPropertyChanged();
            }
        }

        private bool isNewCharacter { get; set; }

        public CharactersViewModel CharactersVM { get; set; }

        public EditCharacterViewModel(CharacterModel character, CharactersViewModel charactersVm, bool isNew)
        {
            SelectedCharacter = character;
            CharactersVM = charactersVm;
            isNewCharacter = isNew;

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

            SaveCommand = new RelayCommand(o =>
            {
                SelectedCharacter.Name = Name;
                SelectedCharacter.Age = Age;
                SelectedCharacter.Apparance = Apparance;
                SelectedCharacter.Backstory = Backstory;
                SelectedCharacter.Height = Height;
                SelectedCharacter.Personality = Personality;
                SelectedCharacter.ProfileImage = ProfileImage;
                SelectedCharacter.Race = Race;
                SelectedCharacter.Likes = Likes;
                SelectedCharacter.Dislikes = Dislikes;
                SelectedCharacter.Weight = Weight;
                SelectedCharacter.Gender = Gender;
                if (isNewCharacter)
                {
                    DataController.Instance.AddCharacter(SelectedCharacter);
                }
                CharactersVM.CurrentView = new CharacterDetailsViewModel(SelectedCharacter, CharactersVM);
            });

            CancelCommand = new RelayCommand(o =>
            {
                if (isNewCharacter)
                {
                    CharactersVM.CurrentView = null;
                    SelectedCharacter = null;
                }
                else {
                    CharactersVM.CurrentView = new CharacterDetailsViewModel(SelectedCharacter, CharactersVM);
                }
            });

            OpenFileCommand = new RelayCommand(o =>
            {
                ProfileImage = new OpenFileDialogService().OpenFileDialog();
            });

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
            set
            {
                _height = value;
                OnPropertyChanged();
            }
        }

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged();
            }
        }

        private string _race;

        public string Race
        {
            get { return _race; }
            set
            {
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
