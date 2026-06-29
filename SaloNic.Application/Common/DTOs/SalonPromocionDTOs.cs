using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class SalonPromocionDTOs
    {
        [Key]
        public int IdSalonPromocion { get; set; }

        [Required]
        public int IdSalon { get; set; }

        [Required]
        public int IdPromocion { get; set; }

        public Salon? Salon { get; set; }
        public Promocion? Promocion { get; set; }
    }
}