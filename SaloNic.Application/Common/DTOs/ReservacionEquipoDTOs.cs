using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class ReservacionEquipoDTOs
    {
        [Key]
        public int IdReservacionEquipo { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [Required]
        public int IdEquipo { get; set; }

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        public Reservacion? Reservacion { get; set; }
        public Equipo? Equipo { get; set; }
    }
}