using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Authority.Basic;

namespace Authority
{
    public class AuthorityContext : DbContext
    {
        // Map our 'User' model by convention
        public DbSet<Basic.Action> Actions { get; set; }
        public DbSet<Basic.Authority> Authorities { get; set; }
        public DbSet<FileInfo> Files { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }

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
