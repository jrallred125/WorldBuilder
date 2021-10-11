using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorldBuilder
{
    public abstract class ACharacter
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
        /// <summary>
        /// A list of the titles the character may have. 
        /// </summary>
        public List<string> Titles { get; set; }
        /// <summary>
        /// The age of the character in years.
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// The weight of the character in lbs.
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        /// The race that the character is.
        /// </summary>
        public string Race { get; set; }
        /// <summary>
        /// What the character likes. 
        /// </summary>
        public string Likes { get; set; }
        /// <summary>
        /// What the character dislikes.
        /// </summary>
        public string Dislikes { get; set; }
        /// <summary>
        /// What the character finds enjoyable in a sexual way. 
        /// </summary>
        public string Kinks { get; set; }
        /// <summary>
        /// The story of the character before they were made.
        /// </summary>
        public string Backstory { get; set; }
        /// <summary>
        /// A list of whom the character knows. 
        /// </summary>
        public List<ACharacter> Contacts { get; set; }

        public ACharacter(string name, string personality, string apparance)
        {
            Name = name;
            Personality = personality;
            Apparance = apparance;
            Titles = new List<string>();
            Contacts = new List<ACharacter>();
        }

        /// <summary>
        /// This will add a title to a list of titles the character has been given.
        /// </summary>
        /// <param name="title">The title to be added.</param>
        public void AddTitle(string title)
        {
            Titles.Add(title);
        }
        /// <summary>
        /// This will remove a title from the list of titles the character has been given.
        /// </summary>
        /// <param name="title">The title to be removed.</param>
        public void RemoveTitle(string title)
        {
            Titles.Remove(title);
        }

        /// <summary>
        /// This will add a character to the list of people the current character knows. 
        /// </summary>
        /// <param name="contact">The character to add to the list.</param>
        /// <param name="addToBolth">If the contant should add the character to their list. Default is false.</param>
        public void AddContact(ACharacter contact, bool addToBolth = false)
        {
            if (!Contacts.Contains(contact))
            {
                Contacts.Add(contact);
                if (addToBolth)
                {
                    contact.AddContact(this);
                }
            }
        }
    }
}