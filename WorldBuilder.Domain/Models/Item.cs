using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Domain.Models
{
    public class Item : DBclass
    {
        /// <summary>
        /// The name of the item.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// THe description of the item. 
        /// </summary>
        public string Description { get; set; }
    }
}
