using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class UsuarioServices
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioServices(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UsuarioDTOs>> ListarUsuario()
        {
            var listar = await _repository.ListarUsuarioAsync();
            return listar.Select(u => new UsuarioDTOs
            {
                IdUsuario = u.IdUsuario,
                NombreUsuario = u.NombreUsuario,
                ClaveHash = u.ClaveHash,
                Activo = u.Activo,
                FechaCreacion = u.FechaCreacion,
                FechaModificacion = u.FechaModificacion,
                IdRol = u.IdRol,
                Rol = u.Rol,
                Cliente = u.Cliente,
                Empleado = u.Empleado
            });
        }

        public async Task NuevoUsuario(UsuarioDTOs dto)
        {
            var ousuario = new Usuario
            {
                NombreUsuario = dto.NombreUsuario,
                ClaveHash = dto.ClaveHash,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion,
                FechaModificacion = dto.FechaModificacion,
                Rol = dto.Rol,
                Cliente = dto.Cliente,
                Empleado = dto.Empleado
            };

            await _repository.NuevoUsuarioAsync(ousuario);
        }

        public async Task EditarUsuario(UsuarioDTOs dto)
        {
            var ousuario = new Usuario
            {
                IdUsuario = dto.IdUsuario,
                NombreUsuario = dto.NombreUsuario,
                ClaveHash = dto.ClaveHash,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion,
                FechaModificacion = dto.FechaModificacion,
                IdRol = dto.IdRol,
                Rol = dto.Rol,
                Cliente = dto.Cliente,
                Empleado = dto.Empleado
            };

            await _repository.EditarUsuarioAsync(ousuario);
        }

        public async Task EliminarUsuario(int id)
        {
            await _repository.EliminarUsuarioAsync(id);
        }
    }
}
