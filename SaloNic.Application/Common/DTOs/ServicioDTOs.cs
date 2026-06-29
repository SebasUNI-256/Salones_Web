using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class ServicioDTOs
    {
        [Key]
        public int IdServicio { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Range(typeof(decimal), "0", "9999999999.99")]
        public decimal Precio { get; set; }

        public bool Activo { get; set; } = true;

        [Required]
        public int IdTipoServicio { get; set; }

        public TipoServicio? TipoServicio { get; set; }
    }
}