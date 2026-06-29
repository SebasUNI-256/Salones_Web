using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Empleados")]
public class Empleado
{
    [Key]
    public int IdEmpleado { get; set; }

    [Required]
    public int IdUsuario { get; set; }

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

    [Required]
    public int IdCargo { get; set; }

    public bool Activo { get; set; } = true;

    [DataType(DataType.Date)]
    public DateOnly? FechaContratacion { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    [ForeignKey(nameof(IdUsuario))]
    public Usuario? Usuario { get; set; }

    [ForeignKey(nameof(IdCargo))]
    public Cargo? Cargo { get; set; }
}
