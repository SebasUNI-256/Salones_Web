using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class TipoEventoServices
    {
        private readonly ITipoEventoRepository _repository;

        public TipoEventoServices(ITipoEventoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoEventoDTOs>> ListarTipoEvento()
        {
            var listar = await _repository.ListarTipoEventoAsync();
            return listar.Select(t => new TipoEventoDTOs
            {
                IdTipoEvento = t.IdTipoEvento,
                Nombre = t.Nombre,
                Descripcion = t.Descripcion,
                Activo = t.Activo,
                Reservaciones = t.Reservaciones
            });
        }

        public async Task NuevoTipoEvento(TipoEventoDTOs dto)
        {
            var otipoevento = new TipoEvento
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo,
                Reservaciones = dto.Reservaciones
            };

            await _repository.NuevoTipoEventoAsync(otipoevento);
        }

        public async Task EditarTipoEvento(TipoEventoDTOs dto)
        {
            var otipoevento = new TipoEvento
            {
                IdTipoEvento = dto.IdTipoEvento,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo,
                Reservaciones = dto.Reservaciones
            };

            await _repository.EditarTipoEventoAsync(otipoevento);
        }

        public async Task EliminarTipoEvento(int id)
        {
            await _repository.EliminarTipoEventoAsync(id);
        }
    }
}
