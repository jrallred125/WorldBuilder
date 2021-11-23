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
            string characterfile = "./data/chardata.json";
            if (File.Exists(characterfile))
            {
                string jsonString = File.ReadAllText(characterfile);
                Characters = JsonSerializer.Deserialize<ObservableCollection<CharacterModel>>(jsonString);
            }
            else Characters = new ObservableCollection<CharacterModel>();

            string lorefile = "./data/loredata.json";
            if (File.Exists(lorefile))
            {
                string jsonString = File.ReadAllText(lorefile);
                Lore = JsonSerializer.Deserialize<ObservableCollection<LoreModel>>(jsonString);
            }
            else Lore = new ObservableCollection<LoreModel>();

            string itemfile = "./data/itemsdata.json";
            if (File.Exists(itemfile))
            {
                string jsonString = File.ReadAllText(itemfile);
                Items = JsonSerializer.Deserialize<ObservableCollection<ItemModel>>(jsonString);
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
            WriteCharacters();
            WriteLore();
            WriteItems();
        }

        private void WriteCharacters()
        {
            if (Characters.Count > 0)
            {
                string characterfile = "./data/chardata.json";
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonCharacters = JsonSerializer.Serialize(Characters, options);
                File.WriteAllText(characterfile, jsonCharacters);
            }
        }

        private void WriteLore()
        {
            if (Lore.Count > 0)
            {
                string lorefile = "./data/loredata.json";
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonLore = JsonSerializer.Serialize(Lore, options);
                File.WriteAllText(lorefile, jsonLore);
            }
        }

        private void WriteItems()
        {
            if (Items.Count > 0)
            {
                string itemsfile = "./data/itemsdata.json";
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonLore = JsonSerializer.Serialize(Items, options);
                File.WriteAllText(itemsfile, jsonLore);
            }

        }
    }
}
