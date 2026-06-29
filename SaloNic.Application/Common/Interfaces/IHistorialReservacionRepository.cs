using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IHistorialReservacionRepository
    {
        Task<IEnumerable<HistorialReservacion>> ListarHistorialReservacionAsync();
        Task NuevoHistorialReservacionAsync(HistorialReservacion ohistorialreservacion);
        Task EditarHistorialReservacionAsync(HistorialReservacion ohistorialreservacion);
        Task EliminarHistorialReservacionAsync(int id);
    }
}
