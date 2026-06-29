using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IContratoRepository
    {
        Task<IEnumerable<Contrato>> ListarContratoAsync();
        Task NuevoContratoAsync(Contrato ocontrato);
        Task EditarContratoAsync(Contrato ocontrato);
        Task EliminarContratoAsync(int id);
    }
}
