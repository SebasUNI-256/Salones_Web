using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class EstadoReservacionDTOs
    {
        [Key]
        public int IdEstadoReservacion { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Reservacion> Reservaciones { get; set; } = [];
    }
}
