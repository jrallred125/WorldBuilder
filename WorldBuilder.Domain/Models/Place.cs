using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilder.Domain.Models
{
    public class Place : DBclass
    {
        /// <summary>
        /// The name of the location.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The location of the place.
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// The Description of this place. 
        /// </summary>
        public string Description { get; set; }

    }
}
