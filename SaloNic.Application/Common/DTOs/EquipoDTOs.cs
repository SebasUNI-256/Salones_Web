using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class EquipoDTOs
    {
        [Key]
        public int IdEquipo { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int CantidadDisponible { get; set; }

        public bool Activo { get; set; } = true;

        [Required]
        public int IdTipoEquipo { get; set; }

        public TipoEquipo? TipoEquipo { get; set; }
    }
}
