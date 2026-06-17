using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Sedes")]
public class Sede
{
    [Key]
    public int IdSede { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Direccion { get; set; }

    [Phone, StringLength(20)]
    public string? Telefono { get; set; }

    public bool Activo { get; set; } = true;

    public ICollection<Salon> Salones { get; set; } = [];
}
