using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class TipoEquipoServices
    {
        private readonly ITipoEquipoRepository _repository;

        public TipoEquipoServices(ITipoEquipoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoEquipoDTOs>> ListarTipoEquipo()
        {
            var listar = await _repository.ListarTipoEquipoAsync();
            return listar.Select(t => new TipoEquipoDTOs
            {
                IdTipoEquipo = t.IdTipoEquipo,
                Nombre = t.Nombre
            });
        }

        public async Task NuevoTipoEquipo(TipoEquipoDTOs dto)
        {
            var otipoequipo = new TipoEquipo
            {
                Nombre = dto.Nombre
            };

            await _repository.NuevoTipoEquipoAsync(otipoequipo);
        }

        public async Task EditarTipoEquipo(TipoEquipoDTOs dto)
        {
            var otipoequipo = new TipoEquipo
            {
                IdTipoEquipo = dto.IdTipoEquipo,
                Nombre = dto.Nombre
            };

            await _repository.EditarTipoEquipoAsync(otipoequipo);
        }

        public async Task EliminarTipoEquipo(int id)
        {
            await _repository.EliminarTipoEquipoAsync(id);
        }
    }
}
