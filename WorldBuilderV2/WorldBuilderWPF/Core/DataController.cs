using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.Core
{
    public class DataController
    {
        private static volatile DataController _instance;

        private static object _mylock = new Object();

        public static DataController Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_mylock)
                    {
                        if(_instance == null)
                        {
                            _instance = new DataController();
                        }
                    }
                }
                return _instance;
            }
        }

        public ObservableCollection<CharacterModel> Characters { get; set; }

        private DataController()
        {
            string characterfile = "./data/chardata.json";
            if (File.Exists(characterfile))
            {
                string jsonString = File.ReadAllText(characterfile);
                Characters = JsonSerializer.Deserialize<ObservableCollection<CharacterModel>>(jsonString);
            }
            else
                Characters = new ObservableCollection<CharacterModel>();
        }


        public ObservableCollection<CharacterModel> SearchCharacters(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Characters;
            }
            ObservableCollection<CharacterModel> found = new ObservableCollection<CharacterModel>();
            foreach (var character in Characters)
            {
                if (character.Name.ToLower().Contains(value.ToLower())|| character.Race.ToLower().Contains(value.ToLower())|| character.Gender.ToLower().Contains(value.ToLower()))
                {
                    found.Add(character);
                }
            }
            return found;
        }

        public void AddCharacter(CharacterModel character)
        {
            Characters.Add(character);
        }

        public void RemoveCharacter(CharacterModel character)
        {
            Characters.Remove(character);
        }
        

        public void OnExit()
        {
            WriteCharacters();
        }

        private void WriteCharacters()
        {
            string characterfile = "./data/chardata.json";
            var options = new JsonSerializerOptions {WriteIndented = true};
            string jsonCharacters = JsonSerializer.Serialize(Characters, options);
            File.WriteAllText(characterfile, jsonCharacters);
        }
    }
}
