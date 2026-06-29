using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class EmpleadoServices
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadoServices(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmpleadoDTOs>> ListarEmpleado()
        {
            var listar = await _repository.ListarEmpleadoAsync();
            return listar.Select(e => new EmpleadoDTOs
            {
                IdEmpleado = e.IdEmpleado,
                IdUsuario = e.IdUsuario,
                Cedula = e.Cedula,
                Nombres = e.Nombres,
                Apellidos = e.Apellidos,
                Telefono = e.Telefono,
                Correo = e.Correo,
                IdCargo = e.IdCargo,
                Activo = e.Activo,
                FechaContratacion = e.FechaContratacion,
                FechaCreacion = e.FechaCreacion,
                Usuario = e.Usuario,
                Cargo = e.Cargo
            });
        }

        public async Task NuevoEmpleado(EmpleadoDTOs dto)
        {
            var oempleado = new Empleado
            {
                Cedula = dto.Cedula,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                IdCargo = dto.IdCargo,
                Activo = dto.Activo,
                FechaContratacion = dto.FechaContratacion,
                FechaCreacion = dto.FechaCreacion,
                Usuario = dto.Usuario,
                Cargo = dto.Cargo
            };

            await _repository.NuevoEmpleadoAsync(oempleado);
        }

        public async Task EditarEmpleado(EmpleadoDTOs dto)
        {
            var oempleado = new Empleado
            {
                IdEmpleado = dto.IdEmpleado,
                IdUsuario = dto.IdUsuario,
                Cedula = dto.Cedula,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                IdCargo = dto.IdCargo,
                Activo = dto.Activo,
                FechaContratacion = dto.FechaContratacion,
                FechaCreacion = dto.FechaCreacion,
                Usuario = dto.Usuario,
                Cargo = dto.Cargo
            };

            await _repository.EditarEmpleadoAsync(oempleado);
        }

        public async Task EliminarEmpleado(int id)
        {
            await _repository.EliminarEmpleadoAsync(id);
        }
    }
}
