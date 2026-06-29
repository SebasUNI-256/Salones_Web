using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IContactoClienteRepository
    {
        Task<IEnumerable<ContactoCliente>> ListarContactoClienteAsync();
        Task NuevoContactoClienteAsync(ContactoCliente ocontactocliente);
        Task EditarContactoClienteAsync(ContactoCliente ocontactocliente);
        Task EliminarContactoClienteAsync(int id);
    }
}
