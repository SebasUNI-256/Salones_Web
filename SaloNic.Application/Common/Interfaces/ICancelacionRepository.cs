using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ICancelacionRepository
    {
        Task<IEnumerable<Cancelacion>> ListarCancelacionAsync();
        Task NuevaCancelacionAsync(Cancelacion ocancelacion);
        Task EditarCancelacionAsync(Cancelacion ocancelacion);
        Task EliminarCancelacionAsync(int id);
    }
}
