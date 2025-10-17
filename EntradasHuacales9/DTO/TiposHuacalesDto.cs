using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntradasHuacales9.Controllers;

public class TiposHuacalesDto
{
    public int TipoId { get; set; }
    public string Descripcion { get; set;}
    public int Existencia { get; set; }

}
