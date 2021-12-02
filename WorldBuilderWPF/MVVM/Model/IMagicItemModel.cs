using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    interface IMagicItemModel
    {
        string Rarity { get; set; }

        string Bonus { get; set; }

        bool IsCursed { get; set; }
    }
}
