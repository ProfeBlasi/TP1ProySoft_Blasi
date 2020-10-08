using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using AccesData.Context;
using Aplication.Service;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Commands;
using System.Data;
using SqlKata.Compilers;
using SqlKata.Execution;

namespace AccesData.Queries
{
    public class ClienteQuery : IClienteQuery
    {
        private readonly Contexto contexto;
        public ClienteQuery(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public int getClienteId(string dni)
        {
            return (from x in contexto.Cliente where x.DNI == dni select x.ClienteId).FirstOrDefault<int>();
        }

        public bool ExisteCliente(string dni)
        {
            return contexto.Cliente.Any(x => x.DNI == dni);
        }
    }
}