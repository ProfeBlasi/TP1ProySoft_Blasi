using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Queries
{
    public interface IClienteQuery
    {
        bool ExisteCliente(string dni);
        int getClienteId(string dni);
    }
}
