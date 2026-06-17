using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Promociones")]
public class Promocion
{
    [Key]
    public int IdPromocion { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "100")]
    public decimal Porcentaje { get; set; }

    [DataType(DataType.Date)]
    public DateOnly FechaInicio { get; set; }

    [DataType(DataType.Date)]
    public DateOnly FechaFin { get; set; }

    public bool Activo { get; set; } = true;
}

[Table("SalonPromocion")]
public class SalonPromocion
{
    [Key]
    public int IdSalonPromocion { get; set; }

    [Required]
    public int IdSalon { get; set; }

    [Required]
    public int IdPromocion { get; set; }

    public Salon? Salon { get; set; }
    public Promocion? Promocion { get; set; }
}

[Table("HorariosBloqueados")]
public class HorarioBloqueado
{
    [Key]
    public int IdBloqueo { get; set; }

    [Required]
    public int IdSalon { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    [StringLength(300)]
    public string? Motivo { get; set; }

    public Salon? Salon { get; set; }
}

[Table("Contratos")]
public class Contrato
{
    [Key]
    public int IdContrato { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [Required, StringLength(50)]
    public string NumeroContrato { get; set; } = string.Empty;

    public DateTime FechaContrato { get; set; } = DateTime.Now;

    [StringLength(500)]
    public string? RutaDocumento { get; set; }

    public Reservacion? Reservacion { get; set; }
}

[Table("Cancelaciones")]
public class Cancelacion
{
    [Key]
    public int IdCancelacion { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [StringLength(300)]
    public string? Motivo { get; set; }

    public DateTime FechaCancelacion { get; set; } = DateTime.Now;

    public Reservacion? Reservacion { get; set; }
}

[Table("EvidenciasReservacion")]
public class EvidenciaReservacion
{
    [Key]
    public int IdEvidencia { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [StringLength(255)]
    public string? NombreArchivo { get; set; }

    [StringLength(500)]
    public string? RutaArchivo { get; set; }

    public DateTime FechaSubida { get; set; } = DateTime.Now;

    public Reservacion? Reservacion { get; set; }
}

[Table("HistorialReservacion")]
public class HistorialReservacion
{
    [Key]
    public int IdHistorial { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [StringLength(50)]
    public string? EstadoAnterior { get; set; }

    [StringLength(50)]
    public string? EstadoNuevo { get; set; }

    public DateTime FechaCambio { get; set; } = DateTime.Now;

    public Reservacion? Reservacion { get; set; }
}

[Table("EncuestasSatisfaccion")]
public class EncuestaSatisfaccion
{
    [Key]
    public int IdEncuesta { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [Range(1, 5)]
    public int Calificacion { get; set; }

    [StringLength(500)]
    public string? Comentario { get; set; }

    public DateTime FechaEncuesta { get; set; } = DateTime.Now;

    public Reservacion? Reservacion { get; set; }
}

[Table("Notificaciones")]
public class Notificacion
{
    [Key]
    public int IdNotificacion { get; set; }

    [Required]
    public int IdCliente { get; set; }

    [StringLength(500)]
    public string? Mensaje { get; set; }

    public DateTime FechaEnvio { get; set; } = DateTime.Now;

    public Cliente? Cliente { get; set; }
}

[Table("Bitacora")]
public class Bitacora
{
    [Key]
    public int IdBitacora { get; set; }

    [Required]
    public int IdUsuario { get; set; }

    [Required, StringLength(50)]
    public string Accion { get; set; } = string.Empty;

    [Required, StringLength(50)]
    public string Modulo { get; set; } = string.Empty;

    [StringLength(100)]
    public string? TablaAfectada { get; set; }

    public int? RegistroAfectado { get; set; }

    public string? ValorAnterior { get; set; }

    public string? ValorNuevo { get; set; }

    public DateTime Fecha { get; set; } = DateTime.Now;

    public Usuario? Usuario { get; set; }
}
