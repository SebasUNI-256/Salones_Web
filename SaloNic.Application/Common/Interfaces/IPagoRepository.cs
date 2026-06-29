using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IPagoRepository
    {
        Task<IEnumerable<Pago>> ListarPagoAsync();
        Task NuevoPagoAsync(Pago opago);
        Task EditarPagoAsync(Pago opago);
        Task EliminarPagoAsync(int id);
    }
}
