using Newtonsoft.Json;
using System;
using System.IO;
using WorldBuilderWPF.MVVM.Model;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.Core
{
    public class DataController
    {
        private static volatile DataController _instance;

        private static object _mylock = new Object();

        private string path = "./data/";

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

        private ObservableCollectionEx<string> _worlds;

        public ObservableCollectionEx<string> Worlds
        {
            get { return _worlds; }
            set { _worlds = value; }
        }

        private WorldModel _selectedWorld;

        public WorldModel  SelectedWorld
        {
            get { return _selectedWorld; }
            set { _selectedWorld = value; }
        }

        private void ReadWorld(string name,JsonSerializerSettings settings)
        {
            string worldfile = $"{path}{name}.json";
            if (File.Exists(worldfile))
            {
                string jsonString = File.ReadAllText(worldfile);
                SelectedWorld= JsonConvert.DeserializeObject<WorldModel>(jsonString, settings);
            }
        }

        public void SwapWorlds(string name)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            WriteWorld(settings);
            ReadWorld(name, settings);
        }

        public void AddNewWorld(WorldModel world)
        {
            Worlds.Add(world.Name);
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            WriteWorld(settings);
            SelectedWorld = world;

        }

        public void DeleteWorld()
        {
            string worldPath = $"{path}{SelectedWorld.Name}.json";
            Worlds.Remove(SelectedWorld.Name);
            if (File.Exists(worldPath))
            {
                File.Delete(worldPath);
            }
            SelectedWorld = null;
        }

        private DataController()
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            if (File.Exists($"{path}/worlds.json"))
            {
                string jsonString = File.ReadAllText($"{path}/worlds.json");
                Worlds = JsonConvert.DeserializeObject<ObservableCollectionEx<string>>(jsonString, settings);
            }
            else Worlds = new ObservableCollectionEx<string>();
        }


        public ObservableCollectionEx<CharacterModel> SearchCharacters(string value)
        {
            if (SelectedWorld != null)
            {
                return SelectedWorld.SearchCharacters(value);
            }
            return null;
            
        }

        public ObservableCollectionEx<LoreModel> SearchLores(string value)
        {
            if (SelectedWorld != null)
            {
                return SelectedWorld.SearchLores(value);
            }
            return null;
        }

        public ObservableCollectionEx<IItemModel> SearchItems(string value)
        {
            if (SelectedWorld != null)
            {
                return SelectedWorld.SearchItems(value);
            }
            return null;
        }

        public ObservableCollectionEx<ILocationModel>SearchLocations(string value)
        {
            if (SelectedWorld != null)
            {
                return SelectedWorld.SearchLocations(value);
            }
            return null;
        }

        public void AddCharacter(CharacterModel character)
        {
            SelectedWorld.AddCharacter(character);
        }

        public void RemoveCharacter(CharacterModel character)
        {
            SelectedWorld.RemoveCharacter(character);
        }

        public void AddLore(LoreModel lore)
        {
            SelectedWorld.AddLore(lore);
        }

        public void RemoveLore(LoreModel lore)
        {
            SelectedWorld.RemoveLore(lore);
        }

        public void AddItem(ItemModel item)
        {
            SelectedWorld.AddItem(item);
        }

        public void RemoveItem(ItemModel item)
        {
            SelectedWorld.RemoveItem(item);
        }

        public CharacterModel GetRandomCharacter()
        {
            return SelectedWorld.GetRandomCharacter();           
        }

        public LoreModel GetRandomLore()
        {
            return SelectedWorld.GetRandomLore();            
        }

        public IItemModel GetRandomItem()
        {
            return SelectedWorld.GetRandomItem();
        }

        public ILocationModel GetRandomLocation()
        {
            return SelectedWorld.GetRandomLocation();
        }
        public void OnExit()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            WriteWorld(settings);
            WriteWorldsList(settings);
        }

        private void WriteWorldsList(JsonSerializerSettings settings)
        {
            string worldsPath = $"{path}/worlds.json";
            string jsonCharacters = JsonConvert.SerializeObject(Worlds, settings);
            File.WriteAllText(worldsPath, jsonCharacters);
        }

        private void WriteWorld(JsonSerializerSettings settings)
        {
            if (SelectedWorld != null)
            {
                string worldPath = $"{path}{SelectedWorld.Name}.json";
                string jsonCharacters = JsonConvert.SerializeObject(SelectedWorld, settings);
                File.WriteAllText(worldPath, jsonCharacters);
            }
        }

       
        public void ImportCharacters(string fileName)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                ObservableCollectionEx<CharacterModel> characters = JsonConvert.DeserializeObject<ObservableCollectionEx<CharacterModel>>(jsonString, settings);
                foreach (var character in characters)
                {
                    AddCharacter(character);
                }
                
            }
        }

        public void ExportCharacters(ObservableCollectionEx<CharacterModel> characters, string filepath)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string jsonCharacters = JsonConvert.SerializeObject(characters, settings);
            File.WriteAllText(filepath, jsonCharacters);
        }
        public void ImportLores(string fileName)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                ObservableCollectionEx<LoreModel> lores = JsonConvert.DeserializeObject<ObservableCollectionEx<LoreModel>>(jsonString, settings);
                foreach (var lore in lores)
                {
                    AddLore(lore);
                }
            }
        }

        public void ExportLores(ObservableCollectionEx<LoreModel> lores, string filepath)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string jsonCharacters = JsonConvert.SerializeObject(lores, settings);
            File.WriteAllText(filepath, jsonCharacters);
        }

        public void ImportItems(string fileName)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                ObservableCollectionEx<IItemModel> items = JsonConvert.DeserializeObject<ObservableCollectionEx<IItemModel>>(jsonString, settings);
                foreach (var item in items)
                {
                    AddItem((ItemModel)item);
                }    
            }
        }

        public void ExportItems(ObservableCollectionEx<IItemModel> items, string filepath)
        {
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string jsonCharacters = JsonConvert.SerializeObject(items, settings);
            File.WriteAllText(filepath, jsonCharacters);
        }
    }
}
