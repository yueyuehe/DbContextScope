using Mehdime.Entity.Extension.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehdime.Entity.Extension.Implementations
{
    public abstract class Entity<TDbContext> : IEntity<TDbContext> where TDbContext : DbContext
    {
        private TDbContext _context;
    }
}
