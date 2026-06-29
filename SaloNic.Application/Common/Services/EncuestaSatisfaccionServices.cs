using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class EncuestaSatisfaccionServices
    {
        private readonly IEncuestaSatisfaccionRepository _repository;

        public EncuestaSatisfaccionServices(IEncuestaSatisfaccionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EncuestaSatisfaccionDTOs>> ListarEncuestaSatisfaccion()
        {
            var listar = await _repository.ListarEncuestaSatisfaccionAsync();
            return listar.Select(e => new EncuestaSatisfaccionDTOs
            {
                IdEncuesta = e.IdEncuesta,
                IdReservacion = e.IdReservacion,
                Calificacion = e.Calificacion,
                Comentario = e.Comentario,
                FechaEncuesta = e.FechaEncuesta,
                Reservacion = e.Reservacion
            });
        }

        public async Task NuevaEncuestaSatisfaccion(EncuestaSatisfaccionDTOs dto)
        {
            var oencuestasatisfaccion = new EncuestaSatisfaccion
            {
                Calificacion = dto.Calificacion,
                Comentario = dto.Comentario,
                FechaEncuesta = dto.FechaEncuesta,
                Reservacion = dto.Reservacion
            };

            await _repository.NuevaEncuestaSatisfaccionAsync(oencuestasatisfaccion);
        }

        public async Task EditarEncuestaSatisfaccion(EncuestaSatisfaccionDTOs dto)
        {
            var oencuestasatisfaccion = new EncuestaSatisfaccion
            {
                IdEncuesta = dto.IdEncuesta,
                IdReservacion = dto.IdReservacion,
                Calificacion = dto.Calificacion,
                Comentario = dto.Comentario,
                FechaEncuesta = dto.FechaEncuesta,
                Reservacion = dto.Reservacion
            };

            await _repository.EditarEncuestaSatisfaccionAsync(oencuestasatisfaccion);
        }

        public async Task EliminarEncuestaSatisfaccion(int id)
        {
            await _repository.EliminarEncuestaSatisfaccionAsync(id);
        }
    }
}
