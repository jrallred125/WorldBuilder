﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Core;
using WorldBuilderWPF.MVVM.Model;

namespace WorldBuilderWPF.MVVM.ViewModel
{

    public class WorldViewModel: ObservableObject
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string CharacterName { get; set; } = "";
        public string CharacterImage { get; set; } = "";
        public string CharacterPersonality { get; set; } = "";

        public string LocationName { get; set; } = "";
        public string LocationImage { get; set; } = "";
        public string LocationDescription { get; set; } = "";

        public string LoreTitle { get; set; } = "";
        public string LoreImage { get; set; } = "";
        public string LoreSummary { get; set; } = "";

        public string ItemName { get; set; } = "";
        public string ItemImage { get; set; } = "";
        public string ItemDescription { get; set; } = "";
        public WorldViewModel()
        {
            if (DataController.Instance.SelectedWorld != null)
            {
                UpdatePage();
            }
            
        }

        public void UpdatePage()
        {
            if (DataController.Instance.SelectedWorld != null)
            {
                Name = DataController.Instance.SelectedWorld.Name;
            }
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
            IItemModel item = DataController.Instance.GetRandomItem();
            if (item != null)
            {
                ItemName = item.Name;
                ItemDescription = item.Description;
                ItemImage = item.Image;
            }

            ILocationModel location = DataController.Instance.GetRandomLocation();
            if (location != null)
            {
                LocationName = location.Name;
                LocationDescription = location.Description;
                LocationImage = location.Image;
            }
        }
    }
}
