using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ReservacionEquipoServices
    {
        private readonly IReservacionEquipoRepository _repository;

        public ReservacionEquipoServices(IReservacionEquipoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReservacionEquipoDTOs>> ListarReservacionEquipo()
        {
            var listar = await _repository.ListarReservacionEquipoAsync();
            return listar.Select(r => new ReservacionEquipoDTOs
            {
                IdReservacionEquipo = r.IdReservacionEquipo,
                IdReservacion = r.IdReservacion,
                IdEquipo = r.IdEquipo,
                Cantidad = r.Cantidad,
                Reservacion = r.Reservacion,
                Equipo = r.Equipo
            });
        }

        public async Task NuevoReservacionEquipo(ReservacionEquipoDTOs dto)
        {
            var oreservacionequipo = new ReservacionEquipo
            {
                Cantidad = dto.Cantidad,
                Reservacion = dto.Reservacion,
                Equipo = dto.Equipo
            };

            await _repository.NuevoReservacionEquipoAsync(oreservacionequipo);
        }

        public async Task EditarReservacionEquipo(ReservacionEquipoDTOs dto)
        {
            var oreservacionequipo = new ReservacionEquipo
            {
                IdReservacionEquipo = dto.IdReservacionEquipo,
                IdReservacion = dto.IdReservacion,
                IdEquipo = dto.IdEquipo,
                Cantidad = dto.Cantidad,
                Reservacion = dto.Reservacion,
                Equipo = dto.Equipo
            };

            await _repository.EditarReservacionEquipoAsync(oreservacionequipo);
        }

        public async Task EliminarReservacionEquipo(int id)
        {
            await _repository.EliminarReservacionEquipoAsync(id);
        }
    }
}
