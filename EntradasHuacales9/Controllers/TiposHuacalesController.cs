using EntradasHuacales9.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EntradasHuacales9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposHuacalesController(EntradasHuacalesServices entradasHuacalesServices) : ControllerBase
    {
        // GET: api/<TiposHuacalesController>
        [HttpGet]
        public async Task<TiposHuacalesDto[]> Get()
        {
            return await entradasHuacalesServices.ListarTipos(T => true);
        }

        // GET api/<TiposHuacalesController>/5
        [HttpGet("{id}")]
        public async Task<TiposHuacalesDto[]> Get(int id)
        {
            return await entradasHuacalesServices.ListarTipos(T => T.TipoId == id);
        }

    }
}
