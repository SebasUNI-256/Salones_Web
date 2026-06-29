using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface ISalonPromocionRepository
    {
        Task<IEnumerable<SalonPromocion>> ListarSalonPromocionAsync();
        Task NuevoSalonPromocionAsync(SalonPromocion osalonpromocion);
        Task EditarSalonPromocionAsync(SalonPromocion osalonpromocion);
        Task EliminarSalonPromocionAsync(int id);
    }
}
