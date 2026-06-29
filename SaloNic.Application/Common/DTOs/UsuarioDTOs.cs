using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class UsuarioDTOs
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required, StringLength(50)]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string ClaveHash { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        public DateTime? FechaModificacion { get; set; }

        [Required]
        public int IdRol { get; set; }

        public Rol? Rol { get; set; }
        public Cliente? Cliente { get; set; }
        public Empleado? Empleado { get; set; }
    }
}
