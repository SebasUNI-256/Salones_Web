using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IReservacionServicioRepository
    {
        Task<IEnumerable<ReservacionServicio>> ListarReservacionServicioAsync();
        Task NuevaReservacionServicioAsync(ReservacionServicio oreservacionservicio);
        Task EditarReservacionServicioAsync(ReservacionServicio oreservacionservicio);
        Task EliminarReservacionServicioEquipoAsync(int id);
    }
}
