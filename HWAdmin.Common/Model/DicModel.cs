using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWAdmin.Common.Model
{
    public class DicModel<T> where T : DicItem
    {
        public string Name { get; set; }
        public List<T> Item { get; set; }
    }
}
