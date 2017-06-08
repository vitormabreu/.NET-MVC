using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using VMA.AppCodeFirst.Models;


namespace VMA.AppCodeFirst.DbContext
{
    public class BlogContext : System.Data.Entity.DbContext
    {
        public BlogContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categorias> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Where propertie = classname + "Id" is Key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //Where propertie = string is varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //String MaxLength
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //modelBuilder.Configurations.Add(new PlayerConfig());
            //modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}