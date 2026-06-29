using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class TipoSalonDTOs
    {
        [Key]
        public int IdTipoSalon { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public ICollection<Salon> Salones { get; set; } = [];
    }
}
