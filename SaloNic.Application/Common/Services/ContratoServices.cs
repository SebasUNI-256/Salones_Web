using SaloNic.Application.Common.DTOs;
using SaloNic.Application.Common.Interfaces;
using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Services
{
    public class ContratoServices
    {
        private readonly IContratoRepository _repository;

        public ContratoServices(IContratoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ContratoDTOs>> ListarContrato()
        {
            var listar = await _repository.ListarContratoAsync();
            return listar.Select(c => new ContratoDTOs
            {
                IdContrato = c.IdContrato,
                IdReservacion = c.IdReservacion,
                NumeroContrato = c.NumeroContrato,
                FechaContrato = c.FechaContrato,
                RutaDocumento = c.RutaDocumento,
                Reservacion = c.Reservacion
            });
        }

        public async Task NuevoContrato(ContratoDTOs dto)
        {
            var ocontrato = new Contrato
            {
                NumeroContrato = dto.NumeroContrato,
                FechaContrato = dto.FechaContrato,
                RutaDocumento = dto.RutaDocumento,
                Reservacion = dto.Reservacion
            };

            await _repository.NuevoContratoAsync(ocontrato);
        }

        public async Task EditarContrato(ContratoDTOs dto)
        {
            var ocontrato = new Contrato
            {
                IdContrato = dto.IdContrato,
                IdReservacion = dto.IdReservacion,
                NumeroContrato = dto.NumeroContrato,
                FechaContrato = dto.FechaContrato,
                RutaDocumento = dto.RutaDocumento,
                Reservacion = dto.Reservacion
            };

            await _repository.EditarContratoAsync(ocontrato);
        }

        public async Task EliminarContrato(int id)
        {
            await _repository.EliminarContratoAsync(id);
        }
    }
}
