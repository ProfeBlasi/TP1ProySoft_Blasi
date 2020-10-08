using Domain.Commands;
using Domain.DTO;
using Domain.Entities;
using Domain.Interfaces.Queries;
using Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Service
{
    public class AlquileresService : IAlquileresService
    {
        private readonly IAlquileresQuery _alquileresQuery;
        private readonly IClienteQuery _clienteQuery;
        private readonly ILibroQuery _libroQuery;
        private readonly IGenericRepository _repository;
        public AlquileresService(IAlquileresQuery alquileresQuery, IClienteQuery clienteQuery, ILibroQuery libroQuery, IGenericRepository repository)
        {
            _alquileresQuery = alquileresQuery;
            _clienteQuery = clienteQuery;
            _libroQuery = libroQuery;
            _repository = repository;
        }
        public List<DetalleReserva> GetReservas()
        {
            return _alquileresQuery.GetReservas();
        }

        public string RegistrarProceso(string dni, string isbn, int estado)
        {
            if (_clienteQuery.ExisteCliente(dni) && _libroQuery.ExisteIsbn(isbn))
                switch (estado)
                {
                    case 1:
                        if (_libroQuery.ExisteStock(isbn))
                        {
                            Alquileres alquiler = Proceso(dni, isbn, estado, DateTime.Today, null, DateTime.Today.AddDays(7),true);
                            _repository.Add<Alquileres>(alquiler);
                            return "El alquiler se registro exitosamente";
                        }
                        else
                            return "No contamos con stock para realizar el alquiler";
                    case 2:
                        if (_libroQuery.ExisteStock(isbn))
                        {
                            Alquileres reserva = Proceso(dni, isbn, estado, null, DateTime.Today, null, true);
                            _repository.Add<Alquileres>(reserva);
                            return "La reserva se registro exitosamente";
                        }
                        else
                            return "No contamos con stock para realizar la reserva";
                    case 3:
                        if (_alquileresQuery.ExisteReserva(_clienteQuery.getClienteId(dni),isbn))
                        {
                            Alquileres cancelacion = Proceso(dni, isbn, estado, null, null, null, false);
                            int id = _alquileresQuery.getIdReservaAntigua(_clienteQuery.getClienteId(dni), isbn);
                            _alquileresQuery.ModificarReserva(id, cancelacion);
                            return "Se cancelo la reserva";
                        }
                        else
                            return "El cliente y el libro no tienen reserva asociada para cancelar";
                    default:
                        return "Ocurrio un error inesperado vuelva a intentarlo por favor";
                }
            else
            {
                if (!_clienteQuery.ExisteCliente(dni))
                    return "El dni ingresado no pertence a ningun cliente registrado";
                if (!_libroQuery.ExisteIsbn(isbn))
                    return "El isbn ingresado no pertence a ningun libro registrado";
                else
                    return "Ocurrio un error inesperado vuelva a intentarlo por favor";
            }
        }

        private Alquileres Proceso(string dni, string isbn, int estadoId, DateTime? fechaAlquiler, DateTime? fechaReserva, DateTime? fechaDevolucion, bool descuento)
        {
            Alquileres alqui = new Alquileres();
            {
                alqui.Cliente = _clienteQuery.getClienteId(dni);
                alqui.ISBN = isbn;
                if (descuento)
                    _libroQuery.DescuentoStock(isbn);
                else
                    _libroQuery.AumentoStock(isbn);
                alqui.Estado = estadoId;
                alqui.FechaAlquiler = fechaAlquiler;
                alqui.FechaReserva = fechaReserva;
                alqui.FechaDevolucion = fechaDevolucion;
            };
            return alqui;
        }
    }
}
