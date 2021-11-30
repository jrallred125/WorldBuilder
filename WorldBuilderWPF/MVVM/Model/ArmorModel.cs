using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    [Serializable]
    public class ArmorModel : ItemModel
    {
        /// <summary>
        /// The AC of the armor.
        /// </summary>
        public string ArmorClass { get; set; } = "";

        public ArmorModel()
        {
            Type = "Armor";
        }
    }
}
