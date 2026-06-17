using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("ContactosCliente")]
public class ContactoCliente
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
