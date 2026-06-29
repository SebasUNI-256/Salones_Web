using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class PagoServices
    {
        private readonly IPagoRepository _repository;

        public PagoServices(IPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PagoDTOs>> ListarPago()
        {
            var listar = await _repository.ListarPagoAsync();
            return listar.Select(p => new PagoDTOs
            {
                IdPago = p.IdPago,
                IdReservacion = p.IdReservacion,
                IdMetodoPago = p.IdMetodoPago,
                IdEstadoPago = p.IdEstadoPago,
                Monto = p.Monto,
                FechaPago = p.FechaPago,
                Reservacion = p.Reservacion,
                MetodoPago = p.MetodoPago,
                EstadoPago = p.EstadoPago
            });
        }

        public async Task NuevoPago(PagoDTOs dto)
        {
            var opago = new Pago
            {
                Monto = dto.Monto,
                FechaPago = dto.FechaPago,
                Reservacion = dto.Reservacion,
                MetodoPago = dto.MetodoPago,
                EstadoPago = dto.EstadoPago
            };

            await _repository.NuevoPagoAsync(opago);
        }

        public async Task EditarPago(PagoDTOs dto)
        {
            var opago = new Pago
            {
                IdPago = dto.IdPago,
                IdReservacion = dto.IdReservacion,
                IdMetodoPago = dto.IdMetodoPago,
                IdEstadoPago = dto.IdEstadoPago,
                Monto = dto.Monto,
                FechaPago = dto.FechaPago,
                Reservacion = dto.Reservacion,
                MetodoPago = dto.MetodoPago,
                EstadoPago = dto.EstadoPago
            };

            await _repository.EditarPagoAsync(opago);
        }

        public async Task EliminarPago(int id)
        {
            await _repository.EliminarPagoAsync(id);
        }
    }
}
