using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class MagicArmorModel: ArmorModel, IMagicItemModel
    {
        /// <summary>
        /// How rare the item is. 
        /// </summary>
        public string Rarity { get; set; } = "";
        /// <summary>
        /// The bonus of the item.
        /// </summary>
        public string Bonus { get; set; } = "";
        /// <summary>
        /// Shows if the item is cursed or not.
        /// </summary>
        public bool IsCursed { get; set; } = false;

        public MagicArmorModel(string type) : base(type) { }
        
    }
}
