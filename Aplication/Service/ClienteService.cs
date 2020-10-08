using Domain.Commands;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteQuery _query;
        private readonly IGenericRepository _repository;
        public ClienteService(IClienteQuery query, IGenericRepository repository)
        {
            _query = query;
            _repository = repository;
        }
        public string RegistrarCliente(string dni, string nombre, string apellido, string mail)
        {
            if (_query.ExisteCliente(dni))
                return "Existe un cliente registrado con ese dni";
            else
            {
                Cliente cliente = new Cliente();
                {
                    cliente.Nombre = nombre;
                    cliente.Apellido = apellido;
                    cliente.DNI = dni;
                    cliente.Email = mail;
                };
                _repository.Add<Cliente>(cliente);
                return "El cliente se registro exitosamente, presione una tecla para continuar";
            }
        }
    }
}
