using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class HorarioBloqueadoServices
    {
        private readonly IHorarioBloqueadoRepository _repository;

        public HorarioBloqueadoServices(IHorarioBloqueadoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HorarioBloqueadoDTOs>> ListarHorarioBloqueado()
        {
            var listar = await _repository.ListarHorarioBloqueadoAsync();
            return listar.Select(h => new HorarioBloqueadoDTOs
            {
                IdBloqueo = h.IdBloqueo,
                IdSalon = h.IdSalon,
                FechaInicio = h.FechaInicio,
                FechaFin = h.FechaFin,
                Motivo = h.Motivo,
                Salon = h.Salon
            });
        }

        public async Task NuevoHorarioBloqueado(HorarioBloqueadoDTOs dto)
        {
            var ohorariobloqueado = new HorarioBloqueado
            {
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Motivo = dto.Motivo,
                Salon = dto.Salon
            };

            await _repository.NuevoHorarioBloqueadoAsync(ohorariobloqueado);
        }

        public async Task EditarHorarioBloqueado(HorarioBloqueadoDTOs dto)
        {
            var ohorariobloqueado = new HorarioBloqueado
            {
                IdBloqueo = dto.IdBloqueo,
                IdSalon = dto.IdSalon,
                FechaInicio = dto.FechaInicio,
                FechaFin = dto.FechaFin,
                Motivo = dto.Motivo,
                Salon = dto.Salon
            };

            await _repository.EditarHorarioBloqueadoAsync(ohorariobloqueado);
        }

        public async Task EliminarHorarioBloqueado(int id)
        {
            await _repository.EliminarHorarioBloqueadoAsync(id);
        }
    }
}
