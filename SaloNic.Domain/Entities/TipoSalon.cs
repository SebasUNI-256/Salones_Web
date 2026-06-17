using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("TiposSalon")]
public class TipoSalon
{
    [Key]
    public int IdTipoSalon { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    public bool Activo { get; set; } = true;

    public ICollection<Salon> Salones { get; set; } = [];
}
