using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IMetodoPagoRepository
    {
        Task<IEnumerable<MetodoPago>> ListarMetodoPagoAsync();
        Task NuevoMetodoPagoAsync(MetodoPago ometodopago);
        Task EditarMetodoPagoAsync(MetodoPago ometodopago);
        Task EliminarMetodoPagoAsync(int id);
    }
}
