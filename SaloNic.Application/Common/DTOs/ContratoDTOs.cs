using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class ContratoDTOs
    {
        [Key]
        public int IdContrato { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [Required, StringLength(50)]
        public string NumeroContrato { get; set; } = string.Empty;

        public DateTime FechaContrato { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string? RutaDocumento { get; set; }

        public Reservacion? Reservacion { get; set; }
    }
}