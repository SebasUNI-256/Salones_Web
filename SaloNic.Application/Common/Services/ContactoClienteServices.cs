using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ContactoClienteServices
    {
        private readonly IContactoClienteRepository _repository;

        public ContactoClienteServices(IContactoClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContactoClienteDTOs>> ListarContactoCliente()
        {
            var listar = await _repository.ListarContactoClienteAsync();
            return listar.Select(C => new ContactoClienteDTOs
            {
                IdContacto = C.IdContacto,
                IdCliente = C.IdCliente,
                Nombre = C.Nombre,
                Telefono = C.Telefono,
                Correo = C.Correo,
                Cliente = C.Cliente
            });
        }

        public async Task NuevoContactoCliente(ContactoClienteDTOs dto)
        {
            var ocontactocliente = new ContactoCliente
            {
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Cliente = dto.Cliente
            };

            await _repository.NuevoContactoClienteAsync(ocontactocliente);
        }

        public async Task EditarContactoCliente(ContactoClienteDTOs dto)
        {
            var ocontactocliente = new ContactoCliente
            {
                IdContacto = dto.IdContacto,
                IdCliente = dto.IdCliente,
                Nombre = dto.Nombre,
                Telefono = dto.Telefono,
                Correo = dto.Correo,
                Cliente = dto.Cliente
            };

            await _repository.EditarContactoClienteAsync(ocontactocliente);
        }

        public async Task EliminarContactoCliente(int id)
        {
            await _repository.EliminarContactoClienteAsync(id);
        }
    }
}
