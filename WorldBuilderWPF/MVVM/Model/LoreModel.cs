using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class LoreModel
    {
        /// <summary>
        /// The title of the lore.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The summary of the lore.
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// The inforamtion about the lore.
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// An image of the lore.
        /// </summary>
        public string Image { get; set; }
        /// <summary>
        /// The type of lore it is.
        /// </summary>
        public string Type { get; set; }

    }
}
