using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ListarClienteAsync();
        Task NuevoClienteAsync(Cliente ocliente);
        Task EditarClienteAsync(Cliente ocliente);
        Task EliminarClienteAsync(int id);
    }
}
