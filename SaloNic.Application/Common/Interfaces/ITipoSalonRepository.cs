using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ITipoSalonRepository
    {
        Task<IEnumerable<TipoSalon>> ListarTipoSalonAsync();
        Task NuevoTipoSalonAsync(TipoSalon otiposalon);
        Task EditarTipoSalonAsync(TipoSalon otiposalon);
        Task EliminarTipoSalonAsync(int id);
    }
}
