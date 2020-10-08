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

        public string RegistrarProceso(AlquilerDTO procesoDTO)
        {
            if (_clienteQuery.ExisteCliente(procesoDTO.DNI) && _libroQuery.ExisteIsbn(procesoDTO.ISBN))
                switch (procesoDTO.Estado)
                {
                    case 1:
                        if (_libroQuery.ExisteStock(procesoDTO.ISBN))
                        {
                            Alquileres alquiler = Proceso(procesoDTO, true);
                            _repository.Add<Alquileres>(alquiler);
                            return "El alquiler se registro exitosamente";
                        }
                        else
                            return "No contamos con stock para realizar el alquiler";
                    case 2:
                        if (_libroQuery.ExisteStock(procesoDTO.ISBN))
                        {
                            Alquileres reserva = Proceso(procesoDTO, true);
                            _repository.Add<Alquileres>(reserva);
                            return "La reserva se registro exitosamente";
                        }
                        else
                            return "No contamos con stock para realizar la reserva";
                    case 3:
                        if (_alquileresQuery.ExisteReserva(_clienteQuery.getClienteId(procesoDTO.DNI),procesoDTO.ISBN))
                        {
                            Alquileres cancelacion = Proceso(procesoDTO, false);
                            int id = _alquileresQuery.getIdReservaAntigua(_clienteQuery.getClienteId(procesoDTO.DNI), procesoDTO.ISBN);
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
                if (!_clienteQuery.ExisteCliente(procesoDTO.DNI))
                    return "El dni ingresado no pertence a ningun cliente registrado";
                if (!_libroQuery.ExisteIsbn(procesoDTO.ISBN))
                    return "El isbn ingresado no pertence a ningun libro registrado";
                else
                    return "Ocurrio un error inesperado vuelva a intentarlo por favor";
            }
        }

        private Alquileres Proceso(AlquilerDTO procesoDTO, bool descuento)
        {
            Alquileres alqui = new Alquileres();
            {
                alqui.Cliente = _clienteQuery.getClienteId(procesoDTO.DNI);
                alqui.ISBN = procesoDTO.ISBN;
                if (descuento)
                    _libroQuery.DescuentoStock(procesoDTO.ISBN);
                else
                    _libroQuery.AumentoStock(procesoDTO.ISBN);
                alqui.Estado = procesoDTO.Estado;
                alqui.FechaAlquiler = procesoDTO.FechaAlquiler;
                alqui.FechaReserva = procesoDTO.FechaReserva;
                alqui.FechaDevolucion = procesoDTO.FechaDevolucion;
            };
            return alqui;
        }
    }
}
