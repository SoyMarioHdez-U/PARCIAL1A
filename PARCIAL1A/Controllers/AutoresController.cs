using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;
using Microsoft.EntityFrameworkCore;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly librosContext _librosContext;

        public AutoresController(librosContext librosContext)
        {
            _librosContext = librosContext;
        }

        [HttpGet]
        [Route("GetAll/")]
        public IActionResult Get()
        {

            autores? listaPedidos = (from p in _pruebaContext.pedidos
                                     where p.clienteId == id
                                     select p).FirstOrDefault();

            if (listaPedidos == null)
            {
                return NotFound();
            }

            return Ok(listaPedidos);

        }
    }

    

   
}
