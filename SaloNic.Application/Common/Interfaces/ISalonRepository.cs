using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Salon>> ListarSalonAsync();
        Task NuevoSalonAsync(Salon osalon);
        Task EditarSalonAsync(Salon osalon);
        Task EliminarSalonAsync(int id);
    }
}
