using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface INotificacionRepository
    {
        Task<IEnumerable<Notificacion>> ListarNotificacionAsync();
        Task NuevaNotificacionAsync(Notificacion onotificacion);
        Task EditarNotificacionAsync(Notificacion onotificacion);
        Task EliminarNotificacionAsync(int id);
    }
}
