using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class NotificacionDTOs
    {
        [Key]
        public int IdNotificacion { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [StringLength(500)]
        public string? Mensaje { get; set; }

        public DateTime FechaEnvio { get; set; } = DateTime.Now;

        public Cliente? Cliente { get; set; }
    }
}