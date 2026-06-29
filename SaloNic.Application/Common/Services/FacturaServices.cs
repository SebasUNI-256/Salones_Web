using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class FacturaServices
    {
        private readonly IFacturaRepository _repository;

        public FacturaServices(IFacturaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FacturaDTOs>> ListarFactura()
        {
            var listar = await _repository.ListarFacturaAsync();
            return listar.Select(f => new FacturaDTOs
            {
                IdFactura = f.IdFactura,
                NumeroFactura = f.NumeroFactura,
                IdReservacion = f.IdReservacion,
                SubTotal = f.SubTotal,
                Impuesto = f.Impuesto,
                Total = f.Total,
                FechaFactura = f.FechaFactura,
                Reservacion = f.Reservacion
            });
        }

        public async Task NuevaFactura(FacturaDTOs dto)
        {
            var ofactura = new Factura
            {
                NumeroFactura = dto.NumeroFactura,
                SubTotal = dto.SubTotal,
                Impuesto = dto.Impuesto,
                Total = dto.Total,
                FechaFactura = dto.FechaFactura,
                Reservacion = dto.Reservacion
            };

            await _repository.NuevaFacturaAsync(ofactura);
        }

        public async Task EditarFactura(FacturaDTOs dto)
        {
            var ofactura = new Factura
            {
                IdFactura = dto.IdFactura,
                NumeroFactura = dto.NumeroFactura,
                IdReservacion = dto.IdReservacion,
                SubTotal = dto.SubTotal,
                Impuesto = dto.Impuesto,
                Total = dto.Total,
                FechaFactura = dto.FechaFactura,
                Reservacion = dto.Reservacion
            };

            await _repository.EditarFacturaAsync(ofactura);
        }

        public async Task EliminarFactura(int id)
        {
            await _repository.EliminarFacturaAsync(id);
        }
    }
}
