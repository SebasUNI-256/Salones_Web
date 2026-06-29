using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class TipoServicioServices
    {
        private readonly ITipoServicioRepository _repository;

        public TipoServicioServices(ITipoServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TipoServicioDTOs>> ListarTipoServicio()
        {
            var listar = await _repository.ListarTipoServicioAsync();
            return listar.Select(t => new TipoServicioDTOs
            {
                IdTipoServicio = t.IdTipoServicio,
                Nombre = t.Nombre
            });
        }

        public async Task NuevoTipoServicio(TipoServicioDTOs dto)
        {
            var otiposericio = new TipoServicio
            {
                Nombre = dto.Nombre
            };

            await _repository.NuevoTipoServicioAsync(otiposericio);
        }

        public async Task EditarTipoServicio(TipoServicioDTOs dto)
        {
            var otiposervicio = new TipoServicio
            {
                IdTipoServicio = dto.IdTipoServicio,
                Nombre = dto.Nombre
            };

            await _repository.EditarTipoServicioAsync(otiposervicio);
        }

        public async Task EliminarTipoServicio(int id)
        {
            await _repository.EliminarTipoServicioAsync(id);
        }
    }
}
