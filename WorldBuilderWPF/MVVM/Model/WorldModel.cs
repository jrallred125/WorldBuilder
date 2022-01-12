using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class WorldModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ObservableCollectionEx<string> ItemTypes { get; set; }
        public ObservableCollectionEx<CharacterModel> Characters { get; set; }
        public ObservableCollectionEx<LoreModel> Lores { get; set; }
        public ObservableCollectionEx<IItemModel> Items { get; set; }
        public ObservableCollectionEx<ILocationModel> Locations { get; set; }



        public WorldModel()
        {
            ItemTypes = new();
            Characters = new();
            Lores = new();
            Items = new();
            Locations = new();
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
                if (character.Name.ToLower().Contains(value.ToLower()) || character.Race.ToLower().Contains(value.ToLower()) || character.Gender.ToLower().StartsWith(value.ToLower()))
                {
                    found.Add(character);
                }
            }
            return found;
        }

        public ObservableCollectionEx<LoreModel> SearchLores(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Lores;
            }
            ObservableCollectionEx<LoreModel> found = new ObservableCollectionEx<LoreModel>();
            foreach (var lore in Lores)
            {
                if (lore.Title.ToLower().Contains(value.ToLower()) || lore.Type.ToLower().Contains(value.ToLower()))
                {
                    found.Add(lore);
                }
            }
            return found;
        }

        public ObservableCollectionEx<IItemModel> SearchItems(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Items;
            }
            ObservableCollectionEx<IItemModel> found = new ObservableCollectionEx<IItemModel>();
            foreach (var item in Items)
            {
                if (item.Name.ToLower().Contains(value.ToLower()) || item.Type.ToLower().Contains(value.ToLower()))
                {
                    found.Add(item);
                }
            }
            return found;
        }

        public ObservableCollectionEx<ILocationModel> SearchLocations(string value)
        {
            return null;
        }

        public void AddCharacter(CharacterModel character)
        {
            Characters.Add(character);
            Characters.Sort(p => (p.Race, p.Name));
        }

        public void RemoveCharacter(CharacterModel character)
        {
            Characters.Remove(character);
            Characters.Sort(p => (p.Race, p.Name));
        }

        public void AddLore(LoreModel lore)
        {
            Lores.Add(lore);
            Lores.Sort(p => (p.Type, p.Title));
        }

        public void RemoveLore(LoreModel lore)
        {
            Lores.Remove(lore);
            Lores.Sort(p => (p.Type, p.Title));
        }

        public void AddItem(ItemModel item)
        {
            Items.Add(item);
            Items.Sort(p => (p.Type, p.Name));
        }

        public void RemoveItem(ItemModel item)
        {
            Items.Remove(item);
            Items.Sort(p => (p.Type, p.Name));
        }

        public void AddLocation(ILocationModel location)
        {
            Locations.Add(location);
            Locations.Sort(p => (p.Parent, p.Name));
        }

        public void RemoveLocation(ILocationModel location)
        {
            Locations.Remove(location);
            Locations.Sort(p => (p.Parent, p.Name));
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
            if (Lores.Count > 0)
            {
                Random rand = new Random();
                return Lores[rand.Next(0, Lores.Count)];
            }
            return null;

        }

        public IItemModel GetRandomItem()
        {
            if (Items.Count > 0)
            {
                Random rand = new Random();
                return Items[rand.Next(0, Items.Count)];
            }
            return null;
        }

        public ILocationModel GetRandomLocation()
        {
            if (Locations.Count > 0)
            {
                Random rand = new Random();
                return Locations[rand.Next(0, Locations.Count)];
            }
            return null;
        }



    }
}
