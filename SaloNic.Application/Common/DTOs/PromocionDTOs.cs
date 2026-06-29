using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class PromocionDTOs
    {
        [Key]
        public int IdPromocion { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Range(typeof(decimal), "0", "100")]
        public decimal Porcentaje { get; set; }

        [DataType(DataType.Date)]
        public DateOnly FechaInicio { get; set; }

        [DataType(DataType.Date)]
        public DateOnly FechaFin { get; set; }

        public bool Activo { get; set; } = true;
    }
}