using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{
    public class HomeViewModel: ObservableObject
    {
        public string CharacterName { get; set; } = "";
        public string CharacterImage { get; set; } = "";
        public string CharacterPersonality { get; set; } = "";
        public string LoreTitle { get; set; } = "";
        public string LoreImage { get; set; } = "";
        public string LoreSummary { get; set; } = "";

        public string ItemName { get; set; } = "";
        public string ItemImage { get; set; } = "";
        public string ItemDiscription { get; set; } = "";

        public HomeViewModel()
        {
            CharacterModel character = DataController.Instance.GetRandomCharacter();
            if (character != null)
            {
                CharacterName = character.Name;
                CharacterImage = character.ProfileImage;
                CharacterPersonality = character.Personality;
            }
            LoreModel lore = DataController.Instance.GetRandomLore();
            if (lore != null)
            {
                LoreTitle = lore.Title;
                LoreSummary = lore.Summary;
                LoreImage = lore.Image;
            }            
            ItemModel item = DataController.Instance.GetRandomItem();
            if (item != null)
            {
                ItemName = item.Name;
                ItemDiscription = item.Discription;
                ItemImage = item.Image;
            }
            
        }




    }
}
