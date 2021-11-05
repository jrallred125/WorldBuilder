using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using WorldBuilder.Domain.Models;

namespace WorldBuilder.WPF.ViewModels
{
    public class CharacterViewModel : ViewModelBase
    {
        private readonly Character _character;

        public string Name => _character.ToString();
        public string Race => $"Race: {_character.Race}";
        public string Age => $"Age: {_character.Age}";
        public string Weight => $"Weight: {_character.Weight}lbs";
        public string Height => $"Height: {_character.Height}";
        public string Titles => $"Titles: {_character.GetTitles()}";
        public string Apparance => $"Apparance: {_character.Apparance}";
        public string Personality => $"Personality: {_character.Personality}";
        public string Backstory => $"Back story: {_character.Backstory}";
        public BitmapImage ProfilePic => new BitmapImage(new Uri(_character.GetPofileImage()));


        public CharacterViewModel(Character character)
        {
            Character A = new();
            A.Name = "Damaia Auburn Vanan";
            A.Age = 18;
            A.Race = "Tiefling";
            A.Height = "5 ft 4 in";
            A.Apparance = "She has red hair with purple streaks, green eyes and pink skin. She wears emerald earings and has one of her horns peirced.";
            A.AddTitle("Cap");
            A.AddTitle("Wicked Wine");
            A.SetMainTitle("Cap");
            
            A.AddImage("/Views/Auburn_front_green_eyes.png");
            A.SetProfileImage("/Views/Auburn_front_green_eyes.png");

            _character = character;
            this.OnPropertyChanged("Age");
        }
    }
}
