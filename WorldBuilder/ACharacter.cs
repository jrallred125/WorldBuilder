using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    public abstract class ACharacter : ICharacter
    {
        /// <summary>
        /// The name of the Character.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Character's personality. 
        /// </summary>
        public string Personality { get; set; }
        /// <summary>
        /// The way the character looks and how they dress. 
        /// </summary>
        public string Apparance { get; set; }



        public ACharacter(string _name,string _personality, string _apparance)
        {
            Name = _name;
            Personality = _personality;
            Apparance = _apparance;
        }
    }
}