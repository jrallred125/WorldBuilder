using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldBuilderWPF.Services;

namespace WorldBuilderWPF.MVVM.Model
{
    public class RoomModel :ILocationModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Parent { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ObservableCollectionEx<ILocationModel> Locations { get; set; }

        public RoomModel(string parent)
        {
            Type = "Room";
            Parent = parent;
            Locations = null;
        }
    }
}
