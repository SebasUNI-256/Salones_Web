using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ListarUsuarioAsync();
        Task NuevoUsuarioAsync(Usuario ousuario);
        Task EditarUsuarioAsync(Usuario ousuario);
        Task EliminarUsuarioAsync(int id);
    }
}
