using Newtonsoft.Json;
using System;
using System.IO;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

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

        public ObservableCollectionEx<CharacterModel> Characters { get; set; }

        public ObservableCollectionEx<LoreModel> Lore { get; set; }

        public ObservableCollectionEx<ItemModel> Items { get; set; }


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
                Characters = JsonConvert.DeserializeObject<ObservableCollectionEx<CharacterModel>>(jsonString, settings);
            }
            else Characters = new ObservableCollectionEx<CharacterModel>();

            string lorefile = $"{path}{loreJsonFile}"; ;
            if (File.Exists(lorefile))
            {
                string jsonString = File.ReadAllText(lorefile);
                Lore = JsonConvert.DeserializeObject<ObservableCollectionEx<LoreModel>>(jsonString, settings);
            }
            else Lore = new ObservableCollectionEx<LoreModel>();

            string itemfile = $"{path}{itemsJsonFile}"; ;
            if (File.Exists(itemfile))
            {
                string jsonString = File.ReadAllText(itemfile);
                Items = JsonConvert.DeserializeObject<ObservableCollectionEx<ItemModel>>(jsonString,settings);
            }
            else Items = new ObservableCollectionEx<ItemModel>();
        }


        public ObservableCollectionEx<CharacterModel> SearchCharacters(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new ObservableCollectionEx<CharacterModel>(Characters);
            }
            ObservableCollectionEx<CharacterModel> found = new ObservableCollectionEx<CharacterModel>();
            foreach (var character in Characters)
            {
                if (character.Name.ToLower().Contains(value.ToLower())|| character.Race.ToLower().Contains(value.ToLower())|| character.Gender.ToLower().StartsWith(value.ToLower()))
                {
                    found.Add(character);
                }
            }
            return found;
        }

        public ObservableCollectionEx<LoreModel> SearchLore(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Lore;
            }
            ObservableCollectionEx<LoreModel> found = new ObservableCollectionEx<LoreModel>();
            foreach (var lore in Lore)
            {
                if (lore.Title.ToLower().Contains(value.ToLower()) || lore.Type.ToLower().Contains(value.ToLower()))
                {
                    found.Add(lore);
                }
            }
            return found;
        }

        public ObservableCollectionEx<ItemModel> SearchItems(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Items;
            }
            ObservableCollectionEx<ItemModel> found = new ObservableCollectionEx<ItemModel>();
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
            Characters.Sort(p => p.Name);
        }

        public void RemoveCharacter(CharacterModel character)
        {
            Characters.Remove(character);
            Characters.Sort(p => p.Name);
        }

        public void AddLore(LoreModel lore)
        {
            Lore.Add(lore);
            Lore.Sort(p => p.Title);
        }

        public void RemoveLore(LoreModel lore)
        {
            Lore.Remove(lore);
            Lore.Sort(p => p.Title);
        }

        public void AddItem(ItemModel item)
        {
            Items.Add(item);
            Items.Sort(p => p.Name);
        }

        public void RemoveItem(ItemModel item)
        {
            Items.Remove(item);
            Items.Sort(p => p.Name);
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
