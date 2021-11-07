using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class CharacterDetailsViewModel : ObservableObject
    {

        public CharacterDetailsViewModel(CharacterModel character, CharactersViewModel charactersViewModel)
        {
            SelectedCharacter = character;
            CharactersVM = charactersViewModel;

            Name = SelectedCharacter.Name;
            ProfileImage = SelectedCharacter.ProfileImage;
            Age = SelectedCharacter.Age;
            Weight = SelectedCharacter.Weight;
            Height = SelectedCharacter.Height;
            Gender = SelectedCharacter.Gender;
            Race = SelectedCharacter.Race;


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

        private int _age;

        public int Age
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




    }
}
