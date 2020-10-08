using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class Libros
    {
        [Key][Required][Column(TypeName = "varchar(45)")]
        public string ISBN { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Titulo { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Autor { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Editorial { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Edicion { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Imagen { get; set; }
    }
}