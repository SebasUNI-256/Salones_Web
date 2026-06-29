using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class RolServices
    {
        private readonly IRolRepository _repository;

        public RolServices(IRolRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RolDTOs>> ListarRol()
        {
            var listar = await _repository.ListarRolAsync();
            return listar.Select(r => new RolDTOs
            {
                IdRol = r.IdRol,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Activo = r.Activo,
                Usuarios = r.Usuarios
            });
        }

        public async Task NuevoRol(RolDTOs dto)
        {
            var orol = new Rol
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo,
                Usuarios = dto.Usuarios
            };

            await _repository.NuevoRolAsync(orol);
        }

        public async Task EditarRol(RolDTOs dto)
        {
            var orol = new Rol
            {
                IdRol = dto.IdRol,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo,
                Usuarios = dto.Usuarios
            };

            await _repository.EditarRolAsync(orol);
        }

        public async Task EliminarRol(int id)
        {
            await _repository.EliminarRolAsync(id);
        }
    }
}
