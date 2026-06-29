using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class CancelacionServices
    {
        private readonly ICancelacionRepository _repository;

        public CancelacionServices(ICancelacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CancelacionDTOs>> ListarCancelacion()
        {
            var listar = await _repository.ListarCancelacionAsync();
            return listar.Select(c => new CancelacionDTOs
            {
                IdCancelacion = c.IdCancelacion,
                IdReservacion = c.IdReservacion,
                Motivo = c.Motivo,
                FechaCancelacion = c.FechaCancelacion,
                Reservacion = c.Reservacion
            });
        }

        public async Task NuevaCancelacion(CancelacionDTOs dto)
        {
            var ocancelacion = new Cancelacion
            {
                Motivo = dto.Motivo,
                FechaCancelacion = dto.FechaCancelacion,
                Reservacion = dto.Reservacion
            };

            await _repository.NuevaCancelacionAsync(ocancelacion);
        }

        public async Task EditarCancelacion(CancelacionDTOs dto)
        {
            var ocancelacion = new Cancelacion
            {
                IdCancelacion = dto.IdCancelacion,
                IdReservacion = dto.IdReservacion,
                Motivo = dto.Motivo,
                FechaCancelacion = dto.FechaCancelacion,
                Reservacion = dto.Reservacion

            };

            await _repository.EditarCancelacionAsync(ocancelacion);
        }

        public async Task EliminarCancelacion(int id)
        {
            await _repository.EliminarCancelacionAsync(id);
        }
    }
}
