using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("ReservacionServicio")]
public class ReservacionServicio
{
    [Key]
    public int IdReservacionServicio { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [Required]
    public int IdServicio { get; set; }

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    [Range(typeof(decimal), "0", "9999999999.99")]
    public decimal Precio { get; set; }

    public Reservacion? Reservacion { get; set; }
    public Servicio? Servicio { get; set; }
}

[Table("ReservacionEquipo")]
public class ReservacionEquipo
{
    [Key]
    public int IdReservacionEquipo { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [Required]
    public int IdEquipo { get; set; }

    [Range(1, int.MaxValue)]
    public int Cantidad { get; set; }

    public Reservacion? Reservacion { get; set; }
    public Equipo? Equipo { get; set; }
}

[Table("Pagos")]
public class Pago
{
    [Key]
    public int IdPago { get; set; }

    [Required]
    public int IdReservacion { get; set; }

    [Required]
    public int IdMetodoPago { get; set; }

    [Required]
    public int IdEstadoPago { get; set; }

    [Range(typeof(decimal), "0.01", "9999999999.99")]
    public decimal Monto { get; set; }

    public DateTime FechaPago { get; set; } = DateTime.Now;

    public Reservacion? Reservacion { get; set; }
    public MetodoPago? MetodoPago { get; set; }
    public EstadoPago? EstadoPago { get; set; }
}

[Table("Facturas")]
public class Factura
{
    [Key]
    public int IdFactura { get; set; }

    [Required, StringLength(50)]
    public string NumeroFactura { get; set; } = string.Empty;

    [Required]
    public int IdReservacion { get; set; }

    [Range(typeof(decimal), "0", "9999999999.99")]
    public decimal SubTotal { get; set; }

    [Range(typeof(decimal), "0", "9999999999.99")]
    public decimal Impuesto { get; set; }

    [Range(typeof(decimal), "0", "9999999999.99")]
    public decimal Total { get; set; }

    public DateTime FechaFactura { get; set; } = DateTime.Now;

    public Reservacion? Reservacion { get; set; }
}
