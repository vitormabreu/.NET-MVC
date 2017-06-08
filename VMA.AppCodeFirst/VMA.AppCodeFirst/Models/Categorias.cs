using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VMA.AppCodeFirst.Models
{
    public class Categorias
    {
        [Key]
        public Guid CategoriaId { get; set; }
        public string Categoria { get; set; }
        public string Descrição { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}