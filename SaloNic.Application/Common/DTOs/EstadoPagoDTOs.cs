using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class EstadoPagoDTOs
    {
        [Key]
        public int IdEstadoPago { get; set; }

        [Required, StringLength(50)]
        public string Nombre { get; set; } = string.Empty;
    }
}