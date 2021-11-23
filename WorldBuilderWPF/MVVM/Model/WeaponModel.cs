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
        public string Damage { get; set; }

        public WeaponModel()
        {
            Type = "Weapon";
        }
    }
}
