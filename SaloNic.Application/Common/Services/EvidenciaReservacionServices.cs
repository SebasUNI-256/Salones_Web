using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class EvidenciaReservacionServices
    {
        private readonly IEvidenciaReservacionRepository _repository;

        public EvidenciaReservacionServices(IEvidenciaReservacionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EvidenciaReservacionDTOs>> ListarEvidenciaReservacion()
        {
            var listar = await _repository.ListarEvidenciaReservacionAsync();
            return listar.Select(e => new EvidenciaReservacionDTOs
            {
                IdEvidencia = e.IdEvidencia,
                IdReservacion = e.IdReservacion,
                NombreArchivo = e.NombreArchivo,
                RutaArchivo = e.RutaArchivo,
                FechaSubida = e.FechaSubida,
                Reservacion = e.Reservacion
            });
        }

        public async Task NuevaEvidenciaReservacion(EvidenciaReservacionDTOs dto)
        {
            var oevidenciareservacion = new EvidenciaReservacion
            {
                NombreArchivo = dto.NombreArchivo,
                RutaArchivo = dto.RutaArchivo,
                FechaSubida = dto.FechaSubida,
                Reservacion = dto.Reservacion
            };

            await _repository.NuevaEvidenciaReservacionAsync(oevidenciareservacion);
        }

        public async Task EditarEvidenciaReservacion(EvidenciaReservacionDTOs dto)
        {
            var oevidenciareservacion = new EvidenciaReservacion
            {
                IdEvidencia = dto.IdEvidencia,
                IdReservacion = dto.IdReservacion,
                NombreArchivo = dto.NombreArchivo,
                RutaArchivo = dto.RutaArchivo,
                FechaSubida = dto.FechaSubida,
                Reservacion = dto.Reservacion
            };

            await _repository.EditarEvidenciaReservacionAsync(oevidenciareservacion);
        }


        public async Task EliminarEvidenciaReservacion(int id)
        {
            await _repository.EliminarEvidenciaReservacionAsync(id);
        }
    }
}
