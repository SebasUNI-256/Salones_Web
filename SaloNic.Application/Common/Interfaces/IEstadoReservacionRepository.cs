using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IEstadoReservacionRepository
    {
        Task<IEnumerable<EstadoReservacion>> ListarEstadoReservacionAsync();
        Task NuevoEstadoReservacionAsync(EstadoReservacion oestadoreservacion);
        Task EditarEstadoReservacionAsync(EstadoReservacion oestadoreservacion);
        Task EliminarEstadoReservacionAsync(int id);
    }
}
