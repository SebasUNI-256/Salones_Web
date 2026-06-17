using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("EstadosReservacion")]
public class EstadoReservacion
{
    [Key]
    public int IdEstadoReservacion { get; set; }

    [Required, StringLength(50)]
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Reservacion> Reservaciones { get; set; } = [];
}
