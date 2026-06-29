using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class HistorialReservacionServices
    {
        private readonly IHistorialReservacionRepository _repository;

        public HistorialReservacionServices(IHistorialReservacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistorialReservacionDTOs>> ListarHistorialReservacion()
        {
            var listar = await _repository.ListarHistorialReservacionAsync();
            return listar.Select(h => new HistorialReservacionDTOs
            {
                IdHistorial = h.IdHistorial,
                IdReservacion = h.IdReservacion,
                IdUsuarioCambio = h.IdUsuarioCambio,
                IdEstadoAnterior = h.IdEstadoAnterior,
                IdEstadoNuevo = h.IdEstadoNuevo,
                Observacion = h.Observacion,
                FechaCambio = h.FechaCambio,
                Reservacion = h.Reservacion,
                UsuarioCambio = h.UsuarioCambio,
                EstadoAnterior = h.EstadoAnterior,
                EstadoNuevo = h.EstadoNuevo
            });
        }

        public async Task NuevoHistorialReservacion(HistorialReservacionDTOs dto)
        {
            var ohistorialreservacion = new HistorialReservacion
            {
                IdReservacion = dto.IdReservacion,
                IdUsuarioCambio = dto.IdUsuarioCambio,
                IdEstadoAnterior = dto.IdEstadoAnterior,
                IdEstadoNuevo = dto.IdEstadoNuevo,
                Observacion = dto.Observacion,
                FechaCambio = dto.FechaCambio,
                Reservacion = dto.Reservacion,
                UsuarioCambio = dto.UsuarioCambio,
                EstadoAnterior = dto.EstadoAnterior,
                EstadoNuevo = dto.EstadoNuevo
            };

            await _repository.NuevoHistorialReservacionAsync(ohistorialreservacion);
        }

        public async Task EditarHistorialReservacion(HistorialReservacionDTOs dto)
        {
            var ohistorialreservacion = new HistorialReservacion
            {
                IdHistorial = dto.IdHistorial,
                IdReservacion = dto.IdReservacion,
                IdUsuarioCambio = dto.IdUsuarioCambio,
                IdEstadoAnterior = dto.IdEstadoAnterior,
                IdEstadoNuevo = dto.IdEstadoNuevo,
                Observacion = dto.Observacion,
                FechaCambio = dto.FechaCambio,
                Reservacion = dto.Reservacion,
                UsuarioCambio = dto.UsuarioCambio,
                EstadoAnterior = dto.EstadoAnterior,
                EstadoNuevo = dto.EstadoNuevo
            };

            await _repository.EditarHistorialReservacionAsync(ohistorialreservacion);
        }

        public async Task EliminarHistorialReservacion(int id)
        {
            await _repository.EliminarHistorialReservacionAsync(id);
        }
    }
}
