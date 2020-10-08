using Domain.Commands;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Service
{
    public class LibroService : ILibroService
    {
        private readonly ILibroQuery _query;
        private readonly IGenericRepository _repository;
        public LibroService(ILibroQuery query, IGenericRepository repository)
        {
            _query = query;
            _repository = repository;
        }
        public List<Libros> GetLibros()
        {
            return _query.GetLibros();
        }
    }
}
