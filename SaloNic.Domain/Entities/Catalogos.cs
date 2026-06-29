using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaloNic.Domain.Entities;

[Table("Cargos")]
public class Cargo
{
    [Key]
    public int IdCargo { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [StringLength(200)]
    public string? Descripcion { get; set; }

    public bool Activo { get; set; } = true;
}

[Table("TiposEquipo")]
public class TipoEquipo
{
    [Key]
    public int IdTipoEquipo { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;
}

[Table("Equipos")]
public class Equipo
{
    [Key]
    public int IdEquipo { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Range(0, int.MaxValue)]
    public int CantidadDisponible { get; set; }

    public bool Activo { get; set; } = true;

    [Required]
    public int IdTipoEquipo { get; set; }

    public TipoEquipo? TipoEquipo { get; set; }
}

[Table("TiposServicio")]
public class TipoServicio
{
    [Key]
    public int IdTipoServicio { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;
}

[Table("Servicios")]
public class Servicio
{
    [Key]
    public int IdServicio { get; set; }

    [Required, StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Range(typeof(decimal), "0", "9999999999.99")]
    public decimal Precio { get; set; }

    public bool Activo { get; set; } = true;

    [Required]
    public int IdTipoServicio { get; set; }

    public TipoServicio? TipoServicio { get; set; }
}

[Table("MetodosPago")]
public class MetodoPago
{
    [Key]
    public int IdMetodoPago { get; set; }

    [Required, StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
}

[Table("EstadosPago")]
public class EstadoPago
{
    [Key]
    public int IdEstadoPago { get; set; }

    [Required, StringLength(50)]
    public string Nombre { get; set; } = string.Empty;
}
