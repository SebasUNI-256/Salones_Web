using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class TipoEventoDTOs
    {
        [Key]
        public int IdTipoEvento { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Reservacion> Reservaciones { get; set; } = [];
    }
}
