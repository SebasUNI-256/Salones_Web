using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ServicioServices
    {
        private readonly IServicioRepository _repository;

        public ServicioServices(IServicioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServicioDTOs>> ListarServicio()
        {
            var listar = await _repository.ListarServicioAsync();
            return listar.Select(s => new ServicioDTOs
            {
                IdServicio = s.IdServicio,
                Nombre = s.Nombre,
                Precio = s.Precio,
                Activo = s.Activo,
                IdTipoServicio = s.IdTipoServicio,
                TipoServicio = s.TipoServicio
            });
        }

        public async Task NuevoServicio(ServicioDTOs dto)
        {
            var oservicio = new Servicio
            {
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Activo = dto.Activo,
                TipoServicio = dto.TipoServicio
            };

            await _repository.NuevoServicioAsync(oservicio);
        }

        public async Task EditarServicio(ServicioDTOs dto)
        {
            var oservicio = new Servicio
            {
                IdServicio = dto.IdServicio,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Activo = dto.Activo,
                IdTipoServicio = dto.IdTipoServicio,
                TipoServicio = dto.TipoServicio
            };

            await _repository.EditarServicioAsync(oservicio);
        }

        public async Task EliminarServicio(int id)
        {
            await _repository.EliminarServicioAsync(id);
        }
    }
}
