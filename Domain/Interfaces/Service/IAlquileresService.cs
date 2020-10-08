using Domain.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Service
{
    public interface IAlquileresService
    {
        string RegistrarProceso(AlquilerDTO proceso);
        List<DetalleReserva> GetReservas();
    }
}
