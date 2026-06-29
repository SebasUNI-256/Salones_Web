using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IServicioRepository
    {
        Task<IEnumerable<Servicio>> ListarServicioAsync();
        Task NuevoServicioAsync(Servicio oservicio);
        Task EditarServicioAsync(Servicio oservicio);
        Task EliminarServicioAsync(int id);
    }
}
