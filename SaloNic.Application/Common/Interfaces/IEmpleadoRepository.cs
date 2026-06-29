using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> ListarEmpleadoAsync();
        Task NuevoEmpleadoAsync(Empleado oempleado);
        Task EditarEmpleadoAsync(Empleado oempleado);
        Task EliminarEmpleadoAsync(int id);
    }
}
