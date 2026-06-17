using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("TiposEvento")]
public class TipoEvento
{
    [Key]
    public int IdTipoEvento { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(300)]
    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    public ICollection<Reservacion> Reservaciones { get; set; } = [];
}
