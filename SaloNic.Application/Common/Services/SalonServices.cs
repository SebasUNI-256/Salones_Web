using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class SalonServices
    {
        private readonly ISalonRepository _repository;

        public SalonServices(ISalonRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SalonDTOs>> ListarSalon()
        {
            var listar = await _repository.ListarSalonAsync();
            return listar.Select(s => new SalonDTOs
            {
                IdSalon = s.IdSalon,
                Nombre = s.Nombre,
                Capacidad = s.Capacidad,
                PrecioBase = s.PrecioBase,
                Descripcion = s.Descripcion,
                Activo = s.Activo,
                IdSede = s.IdSede,
                IdTipoSalon = s.IdTipoSalon,
                Sede = s.Sede,
                TipoSalon = s.TipoSalon,
                Reservaciones = s.Reservaciones
            });
        }

        public async Task NuevoSalon(SalonDTOs dto)
        {
            var osalon = new Salon
            {
                Nombre = dto.Nombre,
                Capacidad = dto.Capacidad,
                PrecioBase = dto.PrecioBase,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo,
                Sede = dto.Sede,
                TipoSalon = dto.TipoSalon,
                Reservaciones = dto.Reservaciones
            };

            await _repository.NuevoSalonAsync(osalon);
        }

        public async Task EditarSalon(SalonDTOs dto)
        {
            var osalon = new Salon
            {
                IdSalon = dto.IdSalon,
                Nombre = dto.Nombre,
                Capacidad = dto.Capacidad,
                PrecioBase = dto.PrecioBase,
                Descripcion = dto.Descripcion,
                Activo = dto.Activo,
                IdSede = dto.IdSede,
                IdTipoSalon = dto.IdTipoSalon,
                Sede = dto.Sede,
                TipoSalon = dto.TipoSalon,
                Reservaciones = dto.Reservaciones
            };

            await _repository.EditarSalonAsync(osalon);
        }

        public async Task EliminarSalon(int id)
        {
            await _repository.EliminarSalonAsync(id);
        }
    }
}
