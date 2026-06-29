using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class HistorialReservacionDTOs
    {
        [Key]
        public int IdHistorial { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [Required]
        public int IdUsuarioCambio { get; set; }

        public int? IdEstadoAnterior { get; set; }

        public int? IdEstadoNuevo { get; set; }

        [StringLength(500)]
        public string? Observacion { get; set; }

        public DateTime FechaCambio { get; set; } = DateTime.Now;

        public Reservacion? Reservacion { get; set; }
        public Usuario? UsuarioCambio { get; set; }
        public EstadoReservacion? EstadoAnterior { get; set; }
        public EstadoReservacion? EstadoNuevo { get; set; }
    }
}
