using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class CharacterModel
    {
        /// <summary>
        /// The name of the Character.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The race that the character is.
        /// </summary>
        public string Race { get; set; }
        /// <summary>
        /// The age of the character in years.
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// The weight of the character in lbs.
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// How much the character weights.
        /// </summary>
        public string Weight { get; set; }
        /// <summary>
        /// The gender of the character.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// The way the character looks and how they dress. 
        /// </summary>
        public string Apparance { get; set; }
        /// <summary>
        /// The Character's personality. 
        /// </summary>
        public string Personality { get; set; }
        /// <summary>
        /// What the character likes. 
        /// </summary>
        public string Likes { get; set; }
        /// <summary>
        /// What the character dislikes.
        /// </summary>
        public string Dislikes { get; set; }
        /// <summary>
        /// The story of the character before they were made.
        /// </summary>
        public string Backstory { get; set; }
        /// <summary>
        /// The Image to be used for the character.
        /// </summary>
        public string ProfileImage { get; set; }
    }
}
