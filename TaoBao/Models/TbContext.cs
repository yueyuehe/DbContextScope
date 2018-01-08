using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TaoBao.Models
{
    public class TbContext : DbContext
    {
        public virtual DbSet<Goods> Goods { get; set; }
        public TbContext() : base("name=Test")
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