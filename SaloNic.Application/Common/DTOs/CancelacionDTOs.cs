using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class CancelacionDTOs
    {
        [Key]
        public int IdCancelacion { get; set; }

        [Required]
        public int IdReservacion { get; set; }

        [StringLength(300)]
        public string? Motivo { get; set; }

        public DateTime FechaCancelacion { get; set; } = DateTime.Now;

        public Reservacion? Reservacion { get; set; }
    }

}

