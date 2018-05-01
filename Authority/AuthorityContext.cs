using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Authority.Entity;

namespace Authority
{
    public class AuthorityContext : DbContext
    {
        // Map our 'User' model by convention
        public DbSet<Entity.Action> Action { get; set; }
        public DbSet<Entity.Authority> Authority { get; set; }
        public DbSet<FileInfo> FileInfo { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<PageElement> PageElement { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }

        public AuthorityContext() : base("name=HWAdmin")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Overrides for the convention-based mappings.
            // We're assuming that all our fluent mappings are declared in this assembly.
            //加载 FluentMap 映射配置
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(UserDbContext)));
        }
    }
}
