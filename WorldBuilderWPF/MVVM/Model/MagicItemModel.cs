using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class MagicItemModel : ItemModel
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
        public MagicItemModel(string type) : base(type) { }
    }
}
