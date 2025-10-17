using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales9.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }
    [Required(ErrorMessage = "El campo nombre es obligatorio")]
    public string NombreCliente { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "La cantidad de huacales es un campo obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage ="La cantidad no puede ser un valor menor a 1")]
    public int  Cantidad { get; set; }
    [Required(ErrorMessage = "El importe es un campo obligatorio")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El importe debe ser un valor mayor a 0")]
    public double Importe { get; set; }

    [InverseProperty("EntradaHuacale")]
    public virtual ICollection<EntradasHuacalesDetalle> EntradaHuacaleDetalle { get; set; } = [];

    [ForeignKey("TipoId")]
    public virtual ICollection<TiposHuacales> TipoHuacale { get; set; } = new List<TiposHuacales>();
}
