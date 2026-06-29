using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IEstadoPagoRepository
    {
        Task<IEnumerable<EstadoPago>> ListarEstadoPagoAsync();
        Task NuevoEstadoPagoAsync(EstadoPago oestadopago);
        Task EditarEstadoPagoAsync(EstadoPago oestadopago);
        Task EliminarEstadoPagoAsync(int id);
    }
}
