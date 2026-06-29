using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ITipoServicioRepository
    {
        Task<IEnumerable<TipoServicio>> ListarTipoServicioAsync();
        Task NuevoTipoServicioAsync(TipoServicio otiposervicio);
        Task EditarTipoServicioAsync(TipoServicio otiposervicio);
        Task EliminarTipoServicioAsync(int id);
    }
}
