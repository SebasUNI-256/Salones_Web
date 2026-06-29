using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ReservacionServicioServices
    {
        private readonly IReservacionServicioRepository _repository;

        public ReservacionServicioServices(IReservacionServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReservacionServicioDTOs>> ListarReservacionServicio()
        {
            var listar = await _repository.ListarReservacionServicioAsync();
            return listar.Select(r => new ReservacionServicioDTOs
            {
                IdReservacionServicio = r.IdReservacionServicio,
                IdReservacion = r.IdReservacion,
                IdServicio = r.IdServicio,
                Cantidad = r.Cantidad,
                Precio = r.Precio,
                Reservacion = r.Reservacion,
                Servicio = r.Servicio
            });
        }

        public async Task NuevaReservacionServicio(ReservacionServicioDTOs dto)
        {
            var oreservacionservicio = new ReservacionServicio
            {
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
                Reservacion = dto.Reservacion,
                Servicio = dto.Servicio
            };

            await _repository.NuevaReservacionServicioAsync(oreservacionservicio);
        }

        public async Task EditarReservacionServicio(ReservacionServicioDTOs dto)
        {
            var oreservacionservicio = new ReservacionServicio
            {
                IdReservacionServicio = dto.IdReservacionServicio,
                IdReservacion = dto.IdReservacion,
                IdServicio = dto.IdServicio,
                Cantidad = dto.Cantidad,
                Precio = dto.Precio,
                Reservacion = dto.Reservacion,
                Servicio = dto.Servicio
            };

            await _repository.EditarReservacionServicioAsync(oreservacionservicio);
        }

        public async Task EliminarReservacionServicio(int id)
        {
            await _repository.EliminarReservacionServicioEquipoAsync(id);
        }
    }
}
