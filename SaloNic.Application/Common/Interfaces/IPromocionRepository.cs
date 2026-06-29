using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IPromocionRepository
    {
        Task<IEnumerable<Promocion>> ListarPromocionAsync();
        Task NuevaPromocionAsync(Promocion opromocion);
        Task EditarPromocionAsync(Promocion opromocion);
        Task EliminarPromocionAsync(int id);
    }
}
