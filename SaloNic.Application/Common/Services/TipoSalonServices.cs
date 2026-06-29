using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class TipoSalonServices
    {
        private readonly ITipoSalonRepository _repository;

        public TipoSalonServices(ITipoSalonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoSalonDTOs>> ListarTipoSalon()
        {
            var listar = await _repository.ListarTipoSalonAsync();
            return listar.Select(t => new TipoSalonDTOs
            {
                IdTipoSalon = t.IdTipoSalon,
                Nombre = t.Nombre,
                Activo = t.Activo,
                Salones = t.Salones
            });
        }

        public async Task NuevoTipoSalon(TipoSalonDTOs dto)
        {
            var otiposalon = new TipoSalon
            {
                Nombre = dto.Nombre,
                Activo = dto.Activo,
                Salones = dto.Salones
            };

            await _repository.NuevoTipoSalonAsync(otiposalon);
        }

        public async Task EditarTipoSalon(TipoSalonDTOs dto)
        {
            var otiposalon = new TipoSalon
            {
                IdTipoSalon = dto.IdTipoSalon,
                Nombre = dto.Nombre,
                Activo = dto.Activo,
                Salones = dto.Salones
            };

            await _repository.EditarTipoSalonAsync(otiposalon);
        }

        public async Task EliminarTipoSalon(int id)
        {
            await _repository.EliminarTipoSalonAsync(id);
        }
    }
}
