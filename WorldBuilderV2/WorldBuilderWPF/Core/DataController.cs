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


        public ObservableCollection<CharacterModel> Search(string value)
        {
            var found = from Character in Characters
                        where Character.Name.StartsWith(value) || Character.Race.Contains(value)
                        select Character;
            return (ObservableCollection<CharacterModel>)found;
        }

        public void AddCharacter(CharacterModel character)
        {
            Characters.Add(character);
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
