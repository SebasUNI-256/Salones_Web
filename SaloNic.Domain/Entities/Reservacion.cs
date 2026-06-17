using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Reservaciones")]
public class Reservacion
{
    [Key]
    public int IdReservacion { get; set; }

    [Required, StringLength(50)]
    public string CodigoReservacion { get; set; } = string.Empty;

    [Required]
    public int IdCliente { get; set; }

    [Required]
    public int IdSalon { get; set; }

    [Required]
    public int IdTipoEvento { get; set; }

    [Required]
    public int IdEstadoReservacion { get; set; }

    [DataType(DataType.Date)]
    public DateOnly FechaEvento { get; set; }

    [DataType(DataType.Time)]
    public TimeOnly HoraInicio { get; set; }

    [DataType(DataType.Time)]
    public TimeOnly HoraFin { get; set; }

    [Range(1, int.MaxValue)]
    public int CantidadInvitados { get; set; }

    [Range(typeof(decimal), "0", "9999999999.99")]
    public decimal Total { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public Cliente? Cliente { get; set; }
    public Salon? Salon { get; set; }
    public TipoEvento? TipoEvento { get; set; }
    public EstadoReservacion? EstadoReservacion { get; set; }
    public ICollection<ReservacionServicio> Servicios { get; set; } = [];
    public ICollection<ReservacionEquipo> Equipos { get; set; } = [];
}
