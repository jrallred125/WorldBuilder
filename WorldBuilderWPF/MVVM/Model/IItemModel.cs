using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    interface IItemModel
    {
        string Name { get; set; }
  
        string Type { get; set; }
   
        string Description { get; set; }

        string Image { get; set; }

        string Value { get; set; }

        string Weight { get; set; }

        string Properties { get; set; }
    }
}
