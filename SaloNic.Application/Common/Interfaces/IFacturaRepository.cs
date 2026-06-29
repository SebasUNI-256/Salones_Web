using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IFacturaRepository
    {
        Task<IEnumerable<Factura>> ListarFacturaAsync();
        Task NuevaFacturaAsync(Factura ofactura);
        Task EditarFacturaAsync(Factura ofactura);
        Task EliminarFacturaAsync(int id);
    }
}
