using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class MetodoPagoServices
    {
        private readonly IMetodoPagoRepository _repository;

        public MetodoPagoServices(IMetodoPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MetodoPagoDTOs>> ListarMetodoPago()
        {
            var listar = await _repository.ListarMetodoPagoAsync();
            return listar.Select(m => new MetodoPagoDTOs
            {
                IdMetodoPago = m.IdMetodoPago,
                Nombre = m.Nombre
            });
        }

        public async Task NuevoMetodoPago(MetodoPagoDTOs dto)
        {
            var ometodopago = new MetodoPago
            {
                Nombre = dto.Nombre
            };

            await _repository.NuevoMetodoPagoAsync(ometodopago);
        }

        public async Task EditarMetodoPago(MetodoPagoDTOs dto)
        {
            var ometodopago = new MetodoPago
            {
                IdMetodoPago = dto.IdMetodoPago,
                Nombre = dto.Nombre
            };

            await _repository.EditarMetodoPagoAsync(ometodopago);
        }

        public async Task EliminarMetodoPago(int id)
        {
            await _repository.EliminarMetodoPagoAsync(id);
        }
    }
}
