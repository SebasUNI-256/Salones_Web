using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class SalonDTOs
    {
        [Key]
        public int IdSalon { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int Capacidad { get; set; }

        [Range(typeof(decimal), "0", "9999999999.99")]
        public decimal PrecioBase { get; set; }

        [StringLength(300)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; } = true;

        [Required]
        public int IdSede { get; set; }

        [Required]
        public int IdTipoSalon { get; set; }

        public Sede? Sede { get; set; }
        public TipoSalon? TipoSalon { get; set; }
        public ICollection<Reservacion> Reservaciones { get; set; } = [];
    }
}
