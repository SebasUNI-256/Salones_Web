using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IRolRepository
    {
        Task<IEnumerable<Rol>> ListarRolAsync();
        Task NuevoRolAsync(Rol orol);
        Task EditarRolAsync(Rol orol);
        Task EliminarRolAsync(int id);
    }
}
