using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales9.Models;

public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }
    public string NombreCliente { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public int  Cantidad { get; set; }
    public double Importe { get; set; }

    [InverseProperty("entradaHuacale")]
    public virtual ICollection<EntradasHuacalesDetalle> entradaHuacaleDetalle { get; set; } = new List<EntradasHuacalesDetalle>();

}
