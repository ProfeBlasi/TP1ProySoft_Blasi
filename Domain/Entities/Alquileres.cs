using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class Alquileres
    {
        [Required]
        public int Cliente { get; set; }
        [ForeignKey("Cliente")]
        public Cliente cliente { get; set; }
        [Required][Column(TypeName = "varchar(45)")]
        public string ISBN { get; set; }
        [ForeignKey("ISBN")]
        public Libros libros { get; set; }
        [Required]
        public int Estado { get; set; }
        [ForeignKey("Estado")]
        public EstadoDeAlquileres EstadoId { get; set; }
        public int ID { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? FechaAlquiler { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? FechaReserva { get; set; }
        [Column(TypeName = "Date")]
        public DateTime? FechaDevolucion { get; set; }
    }
}