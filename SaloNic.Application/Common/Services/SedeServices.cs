using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class SedeServices
    {
        private readonly ISedeRepository _repository;

        public SedeServices(ISedeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SedeDTOs>> ListarSede()
        {
            var listar = await _repository.ListarSedeAsync();
            return listar.Select(s => new SedeDTOs
            {
                IdSede = s.IdSede,
                Nombre = s.Nombre,
                Direccion = s.Direccion,
                Telefono = s.Telefono,
                Activo = s.Activo,
                Salones = s.Salones
            });
        }

        public async Task NuevaSede(SedeDTOs dto)
        {
            var osede = new Sede
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Activo = dto.Activo,
                Salones = dto.Salones
            };

            await _repository.NuevaSedeAsync(osede);
        }

        public async Task EditarSede(SedeDTOs dto)
        {
            var osede = new Sede
            {
                IdSede = dto.IdSede,
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Activo = dto.Activo,
                Salones = dto.Salones
            };

            await _repository.EditarSedeAsync(osede);
        }

        public async Task EliminarSede(int id)
        {
            await _repository.EliminarSedeAsync(id);
        }
    }
}
