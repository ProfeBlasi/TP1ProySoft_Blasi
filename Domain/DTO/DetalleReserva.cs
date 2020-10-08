using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class DetalleReserva
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public string Imagen { get; set; }
        public DateTime? FechaReserva { get; set; }
        public string ApellidoNombre { get; set; }
    }
}
