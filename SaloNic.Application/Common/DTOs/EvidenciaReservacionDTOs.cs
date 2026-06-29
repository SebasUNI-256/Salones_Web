using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class EvidenciaReservacionDTOs
    {
        [Key]
        public int IdEvidencia { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [StringLength(255)]
        public string? NombreArchivo { get; set; }

        [StringLength(500)]
        public string? RutaArchivo { get; set; }

        public DateTime FechaSubida { get; set; } = DateTime.Now;

        public Reservacion? Reservacion { get; set; }
    }
}