using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.Core
{
    [Serializable]
    public class DataController
    {
        private static volatile DataController _instance;

        private static object _mylock = new Object();

        private string path = "./data/";

        private string characterJsonFile = "chardata.json";

        private string loreJsonFile = "loredata.json";

        private string itemsJsonFile = "itemsdata.json";

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

        public ObservableCollection<LoreModel> Lore { get; set; }

        public ObservableCollection<ItemModel> Items { get; set; }


        private DataController()
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string characterfile = $"{path}{characterJsonFile}";
            if (File.Exists(characterfile))
            {
                string jsonString = File.ReadAllText(characterfile);
                Characters = JsonConvert.DeserializeObject<ObservableCollection<CharacterModel>>(jsonString, settings);
            }
            else Characters = new ObservableCollection<CharacterModel>();

            string lorefile = $"{path}{loreJsonFile}"; ;
            if (File.Exists(lorefile))
            {
                string jsonString = File.ReadAllText(lorefile);
                Lore = JsonConvert.DeserializeObject<ObservableCollection<LoreModel>>(jsonString, settings);
            }
            else Lore = new ObservableCollection<LoreModel>();

            string itemfile = $"{path}{itemsJsonFile}"; ;
            if (File.Exists(itemfile))
            {
                string jsonString = File.ReadAllText(itemfile);
                Items = JsonConvert.DeserializeObject<ObservableCollection<ItemModel>>(jsonString,settings);
            }
            else Items = new ObservableCollection<ItemModel>();
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
                if (character.Name.ToLower().Contains(value.ToLower())|| character.Race.ToLower().Contains(value.ToLower())|| character.Gender.ToLower().StartsWith(value.ToLower()))
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

        public ObservableCollection<ItemModel> SearchItems(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Items;
            }
            ObservableCollection<ItemModel> found = new ObservableCollection<ItemModel>();
            foreach (var item in Items)
            {
                if (item.Name.ToLower().Contains(value.ToLower()) || item.Type.ToLower().Contains(value.ToLower()))
                {
                    found.Add(item);
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

        public void AddItem(ItemModel item)
        {
            Items.Add(item);
        }

        public void RemoveItem(ItemModel item)
        {
            Items.Remove(item);
        }

        public CharacterModel GetRandomCharacter()
        {
            if (Characters.Count > 0)
            {
                Random rand = new Random();
                return Characters[rand.Next(0, Characters.Count)];
            }
            return null;
            
        }

        public LoreModel GetRandomLore()
        {
            if (Lore.Count > 0)
            {
                Random rand = new Random();
                return Lore[rand.Next(0, Lore.Count)];
            }
            return null;
            
        }

        public ItemModel GetRandomItem()
        {
            if (Items.Count > 0)
            {
                Random rand = new Random();
                return Items[rand.Next(0, Items.Count)];
            }
            return null;
        }
        public void OnExit()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            WriteCharacters(settings);
            WriteLore(settings);
            WriteItems(settings);
        }

        private void WriteCharacters(JsonSerializerSettings settings)
        {
            if (Characters.Count > 0)
            {
                string characterfile = $"{path}{characterJsonFile}";
                string jsonCharacters = JsonConvert.SerializeObject(Characters, settings);
                File.WriteAllText(characterfile, jsonCharacters);
            }
        }

        private void WriteLore(JsonSerializerSettings settings)
        {
            if (Lore.Count > 0)
            {
                string lorefile = $"{path}{loreJsonFile}";
                string jsonLore = JsonConvert.SerializeObject(Lore, settings);
                File.WriteAllText(lorefile, jsonLore);
            }
        }

        private void WriteItems(JsonSerializerSettings settings)
        {
            if (Items.Count > 0)
            {
                string itemsfile = $"{path}{itemsJsonFile}";
                string jsonItems = JsonConvert.SerializeObject(Items, settings);
                File.WriteAllText(itemsfile, jsonItems);
            }

        }
    }
}
