using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IBitacoraRepository
    {
        Task<IEnumerable<Bitacora>> ListarBitacoraAsync();
        Task NuevaBitacoraAsync(Bitacora obitacora);
        Task EditarBitacoraAsync(Bitacora obitacora);
        Task EliminarBitacoraAsync(int id);
    }
}
