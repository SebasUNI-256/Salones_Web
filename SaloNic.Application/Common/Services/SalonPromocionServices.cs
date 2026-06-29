using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class SalonPromocionServices
    {
        private readonly ISalonPromocionRepository _repository;

        public SalonPromocionServices(ISalonPromocionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalonPromocionDTOs>> ListarSalonPromocion()
        {
            var listar = await _repository.ListarSalonPromocionAsync();
            return listar.Select(s => new SalonPromocionDTOs
            {
                IdSalonPromocion = s.IdSalonPromocion,
                IdSalon = s.IdSalon,
                IdPromocion = s.IdPromocion,
                Salon = s.Salon,
                Promocion = s.Promocion
            });
        }

        public async Task NuevoSalonPromocion(SalonPromocionDTOs dto)
        {
            var osalonpromocion = new SalonPromocion
            {
                Salon = dto.Salon,
                Promocion = dto.Promocion
            };

            await _repository.NuevoSalonPromocionAsync(osalonpromocion);
        }

        public async Task EditarSalonPromocion(SalonPromocionDTOs dto)
        {
            var osalonpromocion = new SalonPromocion
            {
                IdSalonPromocion = dto.IdSalonPromocion,
                IdSalon = dto.IdSalon,
                IdPromocion = dto.IdPromocion,
                Salon = dto.Salon,
                Promocion = dto.Promocion
            };

            await _repository.EditarSalonPromocionAsync(osalonpromocion);
        }

        public async Task EliminarSalonPromocion(int id)
        {
            await _repository.EliminarSalonPromocionAsync(id);
        }
    }
}
