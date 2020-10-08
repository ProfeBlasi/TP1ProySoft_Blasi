using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using AccesData.Context;
using Aplication.Service;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.DTO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AccesData.Queries
{
    public class AlquileresQuery : IAlquileresQuery
    {
        private readonly Contexto contexto;
        public AlquileresQuery(Contexto contexto)
        {
            this.contexto = contexto;
        }
        public bool ExisteReserva(int id, string isbn)
        {
            return contexto.Alquileres.Any(x => x.Cliente == id && x.ISBN == isbn && x.Estado ==2);
        }
        public List<Alquileres> GetAllAlquileres()
        {
            return (from x in contexto.Alquileres select x).ToList();
        }

        public int getIdReservaAntigua(int id, string isbn)
        {
            return (from x in contexto.Alquileres
                    where x.Cliente == id && x.ISBN == isbn
                    && x.Estado == 2
                    orderby x.FechaReserva descending
                    select x.ID).FirstOrDefault<int>();
        }

        public List<DetalleReserva> GetReservas()
        {
            return (from alquileres in GetAllAlquileres()
                    join cliente in (from x in contexto.Cliente select x).ToList()
                    on alquileres.Cliente equals cliente.ClienteId
                    join libros in (from x in contexto.Libros select x).ToList()
                    on alquileres.ISBN equals libros.ISBN
                    where alquileres.Estado == 2
                    select new DetalleReserva
                    {
                        ISBN = libros.ISBN,
                        Titulo = libros.Titulo,
                        Autor = libros.Autor,
                        Editorial = libros.Editorial,
                        Edicion = libros.Edicion,
                        Imagen = libros.Imagen,
                        FechaReserva = alquileres.FechaReserva,
                        ApellidoNombre = cliente.Nombre + " " + cliente.Apellido
                    }).ToList<DetalleReserva>();
        }

        public void ModificarReserva(int id, Alquileres cancelacion)
        {
            var query = (from x in contexto.Alquileres where x.ID == id select x).First();
            query.Estado = 3;
            query.FechaAlquiler = null;
            query.FechaDevolucion = null;
            query.FechaReserva = null;
            contexto.Update(query);
            contexto.SaveChanges();
        }

    }
}