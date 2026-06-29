using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IEquipoRepository
    {
        Task<IEnumerable<Equipo>> ListarEquipoAsync();
        Task NuevoEquipoAsync(Equipo oequipo);
        Task EditarEquipoAsync(Equipo oequipo);
        Task EliminarEquipoAsync(int id);
    }
}
