using SaloNic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaloNic.Application.Common.DTOs
{
    public class ContactoClienteDTOs
    {
        [Key]
        public int IdContacto { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required, StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Phone, StringLength(20)]
        public string? Telefono { get; set; }

        [EmailAddress, StringLength(100)]
        public string? Correo { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
