using EntradasHuacales9.DTO;
using EntradasHuacales9.Models;
using EntradasHuacales9.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntradasHuacales9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradaHuacalesController(EntradasHuacalesServices entradasHuacalesServices) : ControllerBase
    {
        // GET: api/<EntradaHuacalesController>
        [HttpGet]
        public async Task<EntradasHuacalesDto[]> Get()
        {
            return await entradasHuacalesServices.Listar(h => true);
        }

        // GET api/<EntradaHuacalesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EntradaHuacalesController>
        [HttpPost]
        public async Task Post([FromBody] EntradasHuacalesDto entradasHuacales)
        {
            var huacales = new EntradasHuacales
            {
                Fecha = DateTime.Now,
                NombreCliente = entradasHuacales.NombreCliente,
                entradaHuacaleDetalle = entradasHuacales.Huacales.Select(h => new EntradasHuacalesDetalle
                {
                    TipoId = h.IdTipo,
                    Cantidad = h.Cantidad,
                    Precio = h.Precio,
                }).ToArray()
            };
            await entradasHuacalesServices.Guardar(huacales);
        }

        // PUT api/<EntradaHuacalesController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] EntradasHuacalesDto entradasHuacales)
        {
            var huacales = new EntradasHuacales
            {
                IdEntrada = id,
                Fecha = DateTime.Now,
                NombreCliente = entradasHuacales.NombreCliente,
                entradaHuacaleDetalle = entradasHuacales.Huacales.Select(h => new EntradasHuacalesDetalle
                {
                    TipoId = h.IdTipo,
                    Cantidad = h.Cantidad,
                    Precio = h.Precio,
                }).ToArray()
            };
            await entradasHuacalesServices.Guardar(huacales);
        }

        // DELETE api/<EntradaHuacalesController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await entradasHuacalesServices.Eliminar(id);
        }
    }
}
