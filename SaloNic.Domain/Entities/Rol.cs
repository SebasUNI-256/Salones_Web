using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Roles")]
public class Rol
{
    [Key]
    public int IdRol { get; set; }

    [Required, StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public ICollection<Usuario> Usuarios { get; set; } = [];
}
