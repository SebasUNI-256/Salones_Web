using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class PagoDTOs
    {
        [Key]
        public int IdPago { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [Required]
        public int IdMetodoPago { get; set; }

        [Required]
        public int IdEstadoPago { get; set; }

        [Range(typeof(decimal), "0.01", "9999999999.99")]
        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; } = DateTime.Now;

        public Reservacion? Reservacion { get; set; }
        public MetodoPago? MetodoPago { get; set; }
        public EstadoPago? EstadoPago { get; set; }
    }
}