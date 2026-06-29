using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ISedeRepository
    {
        Task<IEnumerable<Sede>> ListarSedeAsync();
        Task NuevaSedeAsync(Sede osede);
        Task EditarSedeAsync(Sede osede);
        Task EliminarSedeAsync(int id);
    }
}
