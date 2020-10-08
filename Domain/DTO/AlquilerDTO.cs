using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class AlquilerDTO
    {
        public string DNI { get; set; }
        public string ISBN { get; set; }
        public int Estado { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }
}
