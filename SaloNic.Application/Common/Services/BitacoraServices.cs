using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class BitacoraServices
    {
        private readonly IBitacoraRepository _repository;

        public BitacoraServices(IBitacoraRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BitacoraDTOs>> ListarBitacora()
        {
            var listar = await _repository.ListarBitacoraAsync();
            return listar.Select(b => new BitacoraDTOs
            {
                IdBitacora = b.IdBitacora,
                IdUsuario = b.IdUsuario,
                Accion = b.Accion,
                Modulo = b.Modulo,
                TablaAfectada = b.TablaAfectada,
                RegistroAfectado = b.RegistroAfectado,
                ValorAnterior = b.ValorAnterior,
                ValorNuevo = b.ValorNuevo,
                Fecha = b.Fecha,
                Usuario = b.Usuario,
            });
        }

        public async Task NuevaBitacora(BitacoraDTOs dto)
        {
            var obitacora = new Bitacora
            {
                Accion = dto.Accion,
                Modulo = dto.Modulo,
                TablaAfectada = dto.TablaAfectada,
                RegistroAfectado = dto.RegistroAfectado,
                ValorAnterior = dto.ValorAnterior,
                ValorNuevo = dto.ValorNuevo,
                Fecha = dto.Fecha,
                Usuario = dto.Usuario,
            };

            await _repository.NuevaBitacoraAsync(obitacora);
        }

        public async Task EditarBitacora(BitacoraDTOs dto)
        {
            var obitacora = new Bitacora
            {
                IdBitacora = dto.IdBitacora,
                IdUsuario = dto.IdUsuario,
                Accion = dto.Accion,
                Modulo = dto.Modulo,
                TablaAfectada = dto.TablaAfectada,
                RegistroAfectado = dto.RegistroAfectado,
                ValorAnterior = dto.ValorAnterior,
                ValorNuevo = dto.ValorNuevo,
                Fecha = dto.Fecha,
                Usuario = dto.Usuario,
            };

            await _repository.EditarBitacoraAsync(obitacora);
        }

        public async Task EliminarBitacora(int id)
        {
            await _repository.EliminarBitacoraAsync(id);
        }
    }
}
