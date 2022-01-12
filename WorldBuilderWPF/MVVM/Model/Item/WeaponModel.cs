using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class WeaponModel : ItemModel
    {
        /// <summary>
        /// The Damage rating of the weapon. 
        /// </summary>
        public string Damage { get; set; }

        public WeaponModel(string type) : base(type) { }
    }
}
