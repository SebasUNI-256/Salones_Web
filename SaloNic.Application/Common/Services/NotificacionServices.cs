using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class NotificacionServices
    {
        private readonly INotificacionRepository _repository;

        public NotificacionServices(INotificacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<NotificacionDTOs>> ListarNotificacion()
        {
            var listar = await _repository.ListarNotificacionAsync();
            return listar.Select(n => new NotificacionDTOs
            {
                IdNotificacion = n.IdNotificacion,
                IdCliente = n.IdCliente,
                Mensaje = n.Mensaje,
                FechaEnvio = n.FechaEnvio,
                Cliente = n.Cliente
            });
        }

        public async Task NuevaNotificacion(NotificacionDTOs dto)
        {
            var onotificacion = new Notificacion
            {
                Mensaje = dto.Mensaje,
                FechaEnvio = dto.FechaEnvio,
                Cliente = dto.Cliente
            };

            await _repository.NuevaNotificacionAsync(onotificacion);
        }

        public async Task EditarNotificacion(NotificacionDTOs dto)
        {
            var onotificacion = new Notificacion
            {
                IdNotificacion = dto.IdNotificacion,
                IdCliente = dto.IdCliente,
                Mensaje = dto.Mensaje,
                FechaEnvio = dto.FechaEnvio,
                Cliente = dto.Cliente
            };

            await _repository.EditarNotificacionAsync(onotificacion);
        }

        public async Task EliminarNotificacion(int id)
        {
            await _repository.EliminarNotificacionAsync(id);
        }
    }
}
