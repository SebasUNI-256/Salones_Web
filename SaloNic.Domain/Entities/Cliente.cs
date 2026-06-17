using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Clientes")]
public class Cliente
{
    [Key]
    public int IdCliente { get; set; }

    [Required, StringLength(20)]
    public string Cedula { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Apellidos { get; set; } = string.Empty;

    [Phone, StringLength(20)]
    public string? Telefono { get; set; }

    [EmailAddress, StringLength(100)]
    public string? Correo { get; set; }

    [StringLength(200)]
    public string? Direccion { get; set; }

    public bool Activo { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public ICollection<ContactoCliente> Contactos { get; set; } = [];
    public ICollection<Reservacion> Reservaciones { get; set; } = [];
}
