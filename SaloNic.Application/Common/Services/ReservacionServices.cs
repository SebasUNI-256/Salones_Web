using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ReservacionServices
    {
        private readonly IReservacionRepository _repository;

        public ReservacionServices(IReservacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReservacionDTOs>> ListarReservacion()
        {
            var listar = await _repository.ListarReservacionAsync();
            return listar.Select(r => new ReservacionDTOs
            {
                IdReservacion = r.IdReservacion,
                CodigoReservacion = r.CodigoReservacion,
                IdCliente = r.IdCliente,
                IdSalon = r.IdSalon,
                IdTipoEvento = r.IdTipoEvento,
                IdEstadoReservacion = r.IdEstadoReservacion,
                IdUsuarioCreacion = r.IdUsuarioCreacion,
                IdUsuarioUltimaModificacion = r.IdUsuarioUltimaModificacion,
                FechaEvento = r.FechaEvento,
                HoraInicio = r.HoraInicio,
                HoraFin = r.HoraFin,
                CantidadInvitados = r.CantidadInvitados,
                Total = r.Total,
                Observaciones = r.Observaciones,
                FechaRegistro = r.FechaRegistro,
                Cliente = r.Cliente,
                Salon = r.Salon,
                TipoEvento = r.TipoEvento,
                EstadoReservacion = r.EstadoReservacion,
                UsuarioCreacion = r.UsuarioCreacion,
                UsuarioUltimaModificacion = r.UsuarioUltimaModificacion,
                Servicios = r.Servicios,
                Equipos = r.Equipos
               
            });
        }

        public async Task NuevaReservacion(ReservacionDTOs dto)
        {
            var oreservacion = new Reservacion
            {
                CodigoReservacion = dto.CodigoReservacion,
                FechaEvento = dto.FechaEvento,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                CantidadInvitados = dto.CantidadInvitados,
                Total = dto.Total,
                Observaciones = dto.Observaciones,
                FechaRegistro = dto.FechaRegistro,
                Cliente = dto.Cliente,
                Salon = dto.Salon,
                TipoEvento = dto.TipoEvento,
                EstadoReservacion = dto.EstadoReservacion,
                UsuarioCreacion = dto.UsuarioCreacion,
                UsuarioUltimaModificacion = dto.UsuarioUltimaModificacion,
                Servicios = dto.Servicios,
                Equipos = dto.Equipos
            };

            await _repository.NuevaReservacionAsync(oreservacion);
        }

        public async Task EditarReservacion(ReservacionDTOs dto)
        {
            var oreservacion = new Reservacion
            {
                IdReservacion = dto.IdReservacion,
                CodigoReservacion = dto.CodigoReservacion,
                IdCliente = dto.IdCliente,
                IdSalon = dto.IdSalon,
                IdTipoEvento = dto.IdTipoEvento,
                IdEstadoReservacion = dto.IdEstadoReservacion,
                IdUsuarioCreacion = dto.IdUsuarioCreacion,
                IdUsuarioUltimaModificacion = dto.IdUsuarioUltimaModificacion,
                FechaEvento = dto.FechaEvento,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                CantidadInvitados = dto.CantidadInvitados,
                Total = dto.Total,
                Observaciones = dto.Observaciones,
                FechaRegistro = dto.FechaRegistro,
                Cliente = dto.Cliente,
                Salon = dto.Salon,
                TipoEvento = dto.TipoEvento,
                EstadoReservacion = dto.EstadoReservacion,
                UsuarioCreacion = dto.UsuarioCreacion,
                UsuarioUltimaModificacion = dto.UsuarioUltimaModificacion,
                Servicios = dto.Servicios,
                Equipos = dto.Equipos
            };

            await _repository.EditarReservacionAsync(oreservacion);
        }

        public async Task EliminarReservacion(int id)
        {
            await _repository.EliminarReservacionAsync(id);
        }
    }
}
