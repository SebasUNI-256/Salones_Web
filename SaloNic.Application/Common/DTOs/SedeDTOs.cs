using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class SedeDTOs
    {
        [Key]
        public int IdSede { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Direccion { get; set; }

        [Phone, StringLength(20)]
        public string? Telefono { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Salon> Salones { get; set; } = [];
    }
}
