using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.Model.Location
{
    [Serializable]
    public class BuildingModel : ILocationModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Parent { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ObservableCollectionEx<ILocationModel> Locations { get; set; }

        public BuildingModel(string parent)
        {
            Type = "Building";
            Parent = parent;
            Locations = new ObservableCollectionEx<ILocationModel>();
        }
    }
}
