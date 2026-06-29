using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IEvidenciaReservacionRepository
    {
        Task<IEnumerable<EvidenciaReservacion>> ListarEvidenciaReservacionAsync();
        Task NuevaEvidenciaReservacionAsync(EvidenciaReservacion oevidenciareservacion);
        Task EditarEvidenciaReservacionAsync(EvidenciaReservacion oevidenciareservacion);
        Task EliminarEvidenciaReservacionAsync(int id);
    }
}
