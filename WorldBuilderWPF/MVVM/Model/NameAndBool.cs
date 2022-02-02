using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldBuilderWPF.MVVM.Model
{
    public class NameAndBool
    {
        public string Name { get; set; }

        public bool Value { get; set; }

        public NameAndBool(string name, bool value)
        {
            Name = name;
            Value = value;
        }
    }
}
