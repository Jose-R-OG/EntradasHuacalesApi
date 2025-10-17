using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales9.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }
    [Required(ErrorMessage = "La descripcion es obligatoria" )]
    public string Descripcion { get; set;}
    [Required(ErrorMessage ="La existencia es un campo obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "La existencia debe ser igual o mayor 1")]
    public int Existencia { get; set; }

    [InverseProperty("TipoHuacale")]
    public virtual ICollection<EntradasHuacales> EntradaHuacale { get; set; } = new List<EntradasHuacales>();
}
