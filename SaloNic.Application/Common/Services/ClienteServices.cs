using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ClienteServices
    {
        private readonly IClienteRepository _repository;

        public ClienteServices(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDTOs>> ListarCliente()
        {
            var listar = await _repository.ListarClienteAsync();
            return listar.Select(c => new ClienteDTOs
            {
                IdCliente = c.IdCliente,
                IdUsuario = c.IdUsuario,
                Cedula = c.Cedula,
                Nombres = c.Nombres,
                Apellidos = c.Apellidos,
                Telefono = c.Telefono,
                Correo = c.Correo,
                Direccion = c.Direccion,
                Activo = c.Activo,
                FechaCreacion = c.FechaCreacion,
                Usuario = c.Usuario,
                Contactos = c.Contactos,
                Reservaciones = c.Reservaciones
            });
        }

        public async Task NuevoCliente(ClienteDTOs dto)
        {
            var ocliente = new Cliente
            {
                Cedula = dto.Cedula,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Direccion = dto.Direccion,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion,
                Usuario = dto.Usuario,
                Contactos = dto.Contactos,
                Reservaciones = dto.Reservaciones

            };

            await _repository.NuevoClienteAsync(ocliente);
        }

        public async Task EditarCliente(ClienteDTOs dto)
        {
            var ocliente = new Cliente
            {
                IdCliente = dto.IdCliente,
                IdUsuario = dto.IdUsuario,
                Cedula = dto.Cedula,
                Nombres = dto.Nombres,
                Apellidos = dto.Apellidos,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Direccion = dto.Direccion,
                Activo = dto.Activo,
                FechaCreacion = dto.FechaCreacion,
                Usuario = dto.Usuario,
                Contactos = dto.Contactos,
                Reservaciones = dto.Reservaciones
            };

            await _repository.EditarClienteAsync(ocliente);
        }

        public async Task EliminarCliente(int id)
        {
            await _repository.EliminarClienteAsync(id);
        }
    }
}
