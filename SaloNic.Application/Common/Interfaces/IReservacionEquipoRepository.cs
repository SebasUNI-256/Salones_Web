using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IReservacionEquipoRepository
    {
        Task<IEnumerable<ReservacionEquipo>> ListarReservacionEquipoAsync();
        Task NuevoReservacionEquipoAsync(ReservacionEquipo oreservacionequipo);
        Task EditarReservacionEquipoAsync(ReservacionEquipo oreservacionequipo);
        Task EliminarReservacionEquipoAsync(int id);
    }
}
