using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales9.Models;

public class EntradasHuacalesDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int EntradaId { get; set; }

    public int TipoId { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad de huacales debe ser mayor que cero")]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El precio es un campo obligatorio")]
    [Range(0.01, int.MaxValue, ErrorMessage = "El precio de los huacales debe ser mayor que cero")]
    public double Precio { get; set; }

    [ForeignKey("IdEntrada")]
    [InverseProperty("entradaHuacaleDetalle")]
    public virtual EntradasHuacales entradaHuacale { get; set; }

    [ForeignKey("TipoId")]
    [InverseProperty("EntradaHuacaleDettalle")]
    public virtual TiposHuacales TiposHuacales { get; set; }
}
