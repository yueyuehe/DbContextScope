using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DisplayAttribute : Attribute
    {
        public DisplayAttribute() { }
        public DisplayAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

    }
}
