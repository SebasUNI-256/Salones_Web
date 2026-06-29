using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class EquipoServices
    {
        private readonly IEquipoRepository _repository;

        public EquipoServices(IEquipoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EquipoDTOs>> ListarEquipo()
        {
            var listar = await _repository.ListarEquipoAsync();
            return listar.Select(e => new EquipoDTOs
            {
                IdEquipo = e.IdEquipo,
                Nombre = e.Nombre,
                CantidadDisponible = e.CantidadDisponible,
                Activo = e.Activo,
                IdTipoEquipo = e.IdTipoEquipo,
                TipoEquipo = e.TipoEquipo
            });
        }

        public async Task NuevoEquipo(EquipoDTOs dto)
        {
            var oequipo = new Equipo
            {
                Nombre = dto.Nombre,
                CantidadDisponible = dto.CantidadDisponible,
                Activo = dto.Activo,
                IdTipoEquipo = dto.IdTipoEquipo,
                TipoEquipo = dto.TipoEquipo
            };

            await _repository.NuevoEquipoAsync(oequipo);
        }

        public async Task EditarEquipo(EquipoDTOs dto)
        {
            var oequipo = new Equipo
            {
                IdEquipo = dto.IdEquipo,
                Nombre = dto.Nombre,
                CantidadDisponible = dto.CantidadDisponible,
                Activo = dto.Activo,
                IdTipoEquipo = dto.IdTipoEquipo,
                TipoEquipo = dto.TipoEquipo
            };

            await _repository.EditarEquipoAsync(oequipo);
        }

        public async Task EliminarEquipo(int id)
        {
            await _repository.EliminarEquipoAsync(id);
        }
    }
}
