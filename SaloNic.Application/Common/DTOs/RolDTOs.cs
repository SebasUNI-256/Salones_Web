using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class RolDTOs
    {
        [Key]
        public int IdRol { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Usuario> Usuarios { get; set; } = [];
    }
}
