using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SaloNic.Application.Common.Interfaces
{
    public interface IEncuestaSatisfaccionRepository
    {
        Task<IEnumerable<EncuestaSatisfaccion>> ListarEncuestaSatisfaccionAsync();
        Task NuevaEncuestaSatisfaccionAsync(EncuestaSatisfaccion oencuestasatisfaccion);
        Task EditarEncuestaSatisfaccionAsync(EncuestaSatisfaccion oencuestasatisfaccion);
        Task EliminarEncuestaSatisfaccionAsync(int id);
    }
}
