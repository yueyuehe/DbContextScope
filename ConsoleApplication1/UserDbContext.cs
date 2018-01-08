using ConsoleApplication1.Module.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class UserDbContext : DbContext
    {
        // Map our 'User' model by convention
        public DbSet<Person> Person { get; set; }

        public UserDbContext() : base("name=Test")
        { }

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
