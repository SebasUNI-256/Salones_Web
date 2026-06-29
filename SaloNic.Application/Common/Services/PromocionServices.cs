using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class PromocionServices
    {
        private readonly IPromocionRepository _repository;

        public PromocionServices(IPromocionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PromocionDTOs>> ListarPromocion()
        {
            var listar = await _repository.ListarPromocionAsync();
            return listar.Select(p => new PromocionDTOs
            {
                IdPromocion = p.IdPromocion,
                Nombre = p.Nombre,
                Porcentaje = p.Porcentaje,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin,
                Activo = p.Activo
            });
        }

        public async Task NuevaPromocion(PromocionDTOs dto)
        {
            var opromocion = new Promocion
            {
                Nombre = dto.Nombre,
                Porcentaje = dto.Porcentaje,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Activo = dto.Activo
            };

            await _repository.NuevaPromocionAsync(opromocion);
        }

        public async Task EditarPromocion(PromocionDTOs dto)
        {
            var opromocion = new Promocion
            {
                IdPromocion = dto.IdPromocion,
                Nombre = dto.Nombre,
                Porcentaje = dto.Porcentaje,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Activo = dto.Activo
            };

            await _repository.EditarPromocionAsync(opromocion);
        }

        public async Task EliminarPromocion(int id)
        {
            await _repository.EliminarPromocionAsync(id);
        }
    }
}
