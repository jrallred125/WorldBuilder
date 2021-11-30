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
        /// The description of the item.
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// The path to the image of the item.
        /// </summary>
        public string Image { get; set; } = "";
        /// <summary>
        /// The cost of the item from a store.
        /// </summary>
        public string Value { get; set; } = "";
        /// <summary>
        /// The sell price to a store.
        /// </summary>
        public string Weight { get; set; } = "";
        /// <summary>
        /// The properties of the item
        /// </summary>
        public string Properties { get; set; } = "";

        public ItemModel(string type)
        {
            Type = type;
        }

    }
}
