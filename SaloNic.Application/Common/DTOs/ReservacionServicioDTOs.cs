using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class ReservacionServicioDTOs
    {
        [Key]
        public int IdReservacionServicio { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [Required]
        public int IdServicio { get; set; }

        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        public decimal Precio { get; set; }

        public Reservacion? Reservacion { get; set; }
        public Servicio? Servicio { get; set; }
    }
}