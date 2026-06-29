using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ITipoEventoRepository
    {
        Task<IEnumerable<TipoEvento>> ListarTipoEventoAsync();
        Task NuevoTipoEventoAsync(TipoEvento otipoevento);
        Task EditarTipoEventoAsync(TipoEvento otipoevento);
        Task EliminarTipoEventoAsync(int id);
    }
}
