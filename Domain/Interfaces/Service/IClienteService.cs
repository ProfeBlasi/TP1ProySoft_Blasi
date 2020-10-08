using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Domain.Interfaces.Service
{
    public interface IClienteService
    {
        string RegistrarCliente(string dni, string nombre, string apellido, string mail);
    }
}
