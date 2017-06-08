using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VMA.AppCodeFirst.Models;


namespace VMA.AppCodeFirst.DbContext
{
    public class BlogContext : System.Data.Entity.DbContext
    {
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}