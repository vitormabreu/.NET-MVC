using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VMA.AppCodeFirst.Models
{
    public class Posts
    {
        [Key]
        public Guid PostId { get; set; }
        public string TituloPost { get; set; }
        public string ResumoPost { get; set; }
        public string ConteudoPost { get; set; }
        public DateTime DataPostagem { get; set; }
        public Guid CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public virtual Categorias Categorias { get; set; }
    }
}