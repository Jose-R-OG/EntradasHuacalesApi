namespace EntradasHuacales9.DTO
{
    public class EntradasHuacalesDto
    {
        public string NombreCliente { get; set; }
        public EntradaHuacalesDetalleDto[] Huacales { get; set; } = [];
    }
}
