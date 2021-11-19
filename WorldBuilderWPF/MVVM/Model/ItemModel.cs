using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class ItemModel
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// The type of the item.
        /// </summary>
        public string Type { get; set; } = "";
        /// <summary>
        /// The discription of the item.
        /// </summary>
        public string Discription { get; set; } = "";
        /// <summary>
        /// The path to the image of the item.
        /// </summary>
        public string Image { get; set; } = "";
        /// <summary>
        /// The cost of the item from a store.
        /// </summary>
        public string PlayerCost { get; set; } = "";
        /// <summary>
        /// The sell price to a store.
        /// </summary>
        public string PlayerSell { get; set; } = "";




    }
}
