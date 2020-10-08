using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class EstadoDeAlquileres
    {
        [Required][Key]
        public int EstadoId { get; set; }
        [Column(TypeName = "varchar(45)")]
        public string Descripcion { get; set; }
    }
}