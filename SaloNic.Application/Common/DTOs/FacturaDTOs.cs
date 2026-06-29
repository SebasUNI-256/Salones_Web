using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class FacturaDTOs
    {
        [Key]
        public int IdFactura { get; set; }

        [Required, StringLength(50)]
        public string NumeroFactura { get; set; } = string.Empty;

        [Required]
        public int IdReservacion { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        public decimal SubTotal { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        public decimal Impuesto { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        public decimal Total { get; set; }

        public DateTime FechaFactura { get; set; } = DateTime.Now;

        public Reservacion? Reservacion { get; set; }
    }
}