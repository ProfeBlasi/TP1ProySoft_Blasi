using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System.Security.Cryptography.X509Certificates;
using AccesData.Context;
using Domain.Entities;
using Domain.Interfaces.Queries;
using System.Data;

namespace AccesData.Queries
{
    public class LibroQuery : ILibroQuery
    {
        private readonly Contexto contexto;
        public LibroQuery(Contexto contexto)
        {
            this.contexto = contexto;
        }

        public void AumentoStock(string isbn)
        {
            var query = (from x in contexto.Libros where x.ISBN == isbn select x).FirstOrDefault();
            query.Stock = query.Stock + 1;
            contexto.Update(query);
        }

        public void DescuentoStock(string isbn)
        {
            var query = (from x in contexto.Libros where x.ISBN == isbn select x).FirstOrDefault();
            query.Stock = query.Stock - 1;
            contexto.Update(query);
        }

        public bool ExisteIsbn(string isbn)
        {
            return contexto.Libros.Any(x => x.ISBN == isbn); 
        }

        public bool ExisteStock(string isbn)
        {
            return contexto.Libros.Any(x => x.ISBN == isbn && x.Stock > 0);
        }

        public List<Libros> GetLibros()
        {
            return (from x in contexto.Libros where x.Stock > 0 select x).ToList();
        }
    }
}