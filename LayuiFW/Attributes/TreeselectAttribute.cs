using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayuiFW.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class TreeselectAttribute : Attribute
    {
        public string Id { get; set; }

        public string Url { get; set; }

        public string Method { get; set; }
    }
}
