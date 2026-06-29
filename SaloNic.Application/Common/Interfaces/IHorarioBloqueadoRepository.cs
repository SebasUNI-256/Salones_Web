using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IHorarioBloqueadoRepository
    {
        Task<IEnumerable<HorarioBloqueado>> ListarHorarioBloqueadoAsync();
        Task NuevoHorarioBloqueadoAsync(HorarioBloqueado ohorariobloqueado);
        Task EditarHorarioBloqueadoAsync(HorarioBloqueado ohorariobloqueado);
        Task EliminarHorarioBloqueadoAsync(int id);
    }
}
