using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class EstadoPagoServices
    {
        private readonly IEstadoPagoRepository _repository;

        public EstadoPagoServices(IEstadoPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EstadoPagoDTOs>> ListarEstadoPago()
        {
            var listar = await _repository.ListarEstadoPagoAsync();
            return listar.Select(e => new EstadoPagoDTOs
            {
                IdEstadoPago = e.IdEstadoPago,
                Nombre = e.Nombre
            });
        }

        public async Task NuevoEstadoPago(EstadoPagoDTOs dto)
        {
            var oestadopago = new EstadoPago
            {
                Nombre = dto.Nombre
            };

            await _repository.NuevoEstadoPagoAsync(oestadopago);
        }

        public async Task EditarEstadoPago(EstadoPagoDTOs dto)
        {
            var oestadopago = new EstadoPago
            {
                IdEstadoPago = dto.IdEstadoPago,
                Nombre = dto.Nombre
            };

            await _repository.EditarEstadoPagoAsync(oestadopago);
        }

        public async Task EliminarEstadoPago(int id)
        {
            await _repository.EliminarEstadoPagoAsync(id);
        }
    }
}
