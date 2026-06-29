using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class HorarioBloqueadoDTOs
    {
        [Key]
        public int IdBloqueo { get; set; }

        [Required]
        public int IdSalon { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        [StringLength(300)]
        public string? Motivo { get; set; }

        public Salon? Salon { get; set; }
    }
}