using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ITipoEquipoRepository
    {
        Task<IEnumerable<TipoEquipo>> ListarTipoEquipoAsync();
        Task NuevoTipoEquipoAsync(TipoEquipo otipoequipo);
        Task EditarTipoEquipoAsync(TipoEquipo otipoequipo);
        Task EliminarTipoEquipoAsync(int id);
    }
}
