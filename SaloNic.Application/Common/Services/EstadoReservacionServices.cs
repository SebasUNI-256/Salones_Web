using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class EstadoReservacionServices
    {
        private readonly IEstadoReservacionRepository _repository;

        public EstadoReservacionServices(IEstadoReservacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EstadoReservacionDTOs>> ListarEstadoReservacion()
        {
            var listar = await _repository.ListarEstadoReservacionAsync();
            return listar.Select(e => new EstadoReservacionDTOs
            {
                IdEstadoReservacion = e.IdEstadoReservacion,
                Nombre = e.Nombre,
                Reservaciones = e.Reservaciones
            });
        }

        public async Task NuevoEstadoReservacion(EstadoReservacionDTOs dto)
        {
            var oestadoreservacion = new EstadoReservacion
            {
                Nombre = dto.Nombre,
                Reservaciones = dto.Reservaciones
            };

            await _repository.NuevoEstadoReservacionAsync(oestadoreservacion);
        }

        public async Task EditarEstadoReservacion(EstadoReservacionDTOs dto)
        {
            var oestadoreservacion = new EstadoReservacion
            {
                IdEstadoReservacion = dto.IdEstadoReservacion,
                Nombre = dto.Nombre,
                Reservaciones = dto.Reservaciones
            };

            await _repository.EditarEstadoReservacionAsync(oestadoreservacion);
        }

        public async Task EliminarEstadoReservacion(int id)
        {
            await _repository.EliminarEstadoReservacionAsync(id);
        }
    }
}
