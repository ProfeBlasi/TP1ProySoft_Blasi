using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Queries
{
    public interface ILibroQuery
    {
        bool ExisteIsbn(string isbn);
        bool ExisteStock(string isbn);
        void DescuentoStock(string isbn);
        void AumentoStock(string isbn);
        List<Libros> GetLibros();
    }
}
