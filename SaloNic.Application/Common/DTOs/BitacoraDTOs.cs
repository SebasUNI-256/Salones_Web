using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class BitacoraDTOs
    {
        [Key]
        public int IdBitacora { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required, StringLength(50)]
        public string Accion { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string Modulo { get; set; } = string.Empty;

        [StringLength(100)]
        public string? TablaAfectada { get; set; }

        public int? RegistroAfectado { get; set; }

        public string? ValorAnterior { get; set; }

        public string? ValorNuevo { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Usuario? Usuario { get; set; }
    }

}
