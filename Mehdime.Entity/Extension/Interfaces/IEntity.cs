using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehdime.Entity.Extension.Interfaces
{
    public interface IEntity<TDbContext> where TDbContext : DbContext
    {
    }
}
