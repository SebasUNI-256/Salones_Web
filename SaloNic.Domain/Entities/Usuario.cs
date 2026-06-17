using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Usuarios")]
public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required, StringLength(50)]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required, StringLength(255)]
    public string Clave { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public DateTime? FechaModificacion { get; set; }

    [Required]
    public int IdRol { get; set; }

    public Rol? Rol { get; set; }
}
