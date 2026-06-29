using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class EncuestaSatisfaccionDTOs
    {
        [Key]
        public int IdEncuesta { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [Range(1, 5)]
        public int Calificacion { get; set; }

        [StringLength(500)]
        public string? Comentario { get; set; }

        public DateTime FechaEncuesta { get; set; } = DateTime.Now;

        public Reservacion? Reservacion { get; set; }
    }
}