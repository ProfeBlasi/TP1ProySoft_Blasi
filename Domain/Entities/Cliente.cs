using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Cliente
    {
        [Key][Required]
        public int ClienteId { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string DNI { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Nombre { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Apellido { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Email { get; set; }
    }
}