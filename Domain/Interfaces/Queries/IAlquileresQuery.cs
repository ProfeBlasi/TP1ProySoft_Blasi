using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Queries
{
    public interface IAlquileresQuery
    {
        bool ExisteReserva(int id, string isbn);
        int getIdReservaAntigua(int id, string isbn);
        List<DetalleReserva> GetReservas();
        void ModificarReserva(int id, Alquileres cancelacion);
    }
}
