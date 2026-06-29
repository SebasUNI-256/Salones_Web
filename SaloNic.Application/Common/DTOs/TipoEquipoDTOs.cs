using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class TipoEquipoDTOs
    {
        [Key]
        public int IdTipoEquipo { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
    }
}