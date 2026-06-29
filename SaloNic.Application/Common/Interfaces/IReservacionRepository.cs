using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IReservacionRepository
    {
        Task<IEnumerable<Reservacion>> ListarReservacionAsync();
        Task NuevaReservacionAsync(Reservacion oreservacion);
        Task EditarReservacionAsync(Reservacion oreservacion);
        Task EliminarReservacionAsync(int id);
    }
}
