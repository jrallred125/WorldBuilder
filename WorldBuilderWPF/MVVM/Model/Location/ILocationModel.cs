using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.Model
{
    public interface ILocationModel
    {
        string Name { get; set; }
        string Type { get; set; }
        string Parent { get; set; }
        string Description { get; set; }
        string Image { get; set; }
        ObservableCollectionEx<ILocationModel> Locations { get; set; }

    }
}
