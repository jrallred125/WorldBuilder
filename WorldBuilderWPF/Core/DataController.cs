using System;
using System.Collections.ObjectModel;
using System.IO;
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

        private ObservableCollection<LoreModel> _lore;

        public ObservableCollection<LoreModel> Lore
        {
            get { return _lore; }
            set { _lore = value; }
        }


        private DataController()
        {
            string characterfile = "./data/chardata.json";
            if (File.Exists(characterfile))
            {
                string jsonString = File.ReadAllText(characterfile);
                Characters = JsonSerializer.Deserialize<ObservableCollection<CharacterModel>>(jsonString);
            }
            else Characters = new ObservableCollection<CharacterModel>();

            string lorefile = "./data/loredata.json";
            if (File.Exists(characterfile))
            {
                string jsonString = File.ReadAllText(lorefile);
                Lore = JsonSerializer.Deserialize<ObservableCollection<LoreModel>>(jsonString);
            }
            else Lore = new ObservableCollection<LoreModel>();
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
                if (character.Name.ToLower().Contains(value.ToLower())|| character.Race.ToLower().Contains(value.ToLower())|| character.Gender.ToLower() == value.ToLower())
                {
                    found.Add(character);
                }
            }
            return found;
        }

        public ObservableCollection<LoreModel> SearchLore(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Lore;
            }
            ObservableCollection<LoreModel> found = new ObservableCollection<LoreModel>();
            foreach (var lore in Lore)
            {
                if (lore.Title.ToLower().Contains(value.ToLower()) || lore.Type.ToLower().Contains(value.ToLower()))
                {
                    found.Add(lore);
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

        public void AddLore(LoreModel lore)
        {
            Lore.Add(lore);
        }

        public void RemoveLore(LoreModel lore)
        {
            Lore.Remove(lore);
        }


        public void OnExit()
        {
            WriteCharacters();
            WriteLore();
        }

        private void WriteCharacters()
        {
            string characterfile = "./data/chardata.json";
            var options = new JsonSerializerOptions {WriteIndented = true};
            string jsonCharacters = JsonSerializer.Serialize(Characters, options);
            File.WriteAllText(characterfile, jsonCharacters);
        }

        private void WriteLore()
        {
            string characterfile = "./data/loredata.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonLore = JsonSerializer.Serialize(Lore, options);
            File.WriteAllText(characterfile, jsonLore);
        }
    }
}
