using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly librosContext _librosContext;

        public LibrosController(librosContext librosContext)
        {
            _librosContext = librosContext;
        }

        [HttpGet]
        [Route("GetAll/")]
        public IActionResult Get()
        {

            Libros? listaLibros = (from p in _librosContext.Libros
                                     select p).FirstOrDefault();

            if (listaLibros == null)
            {
                return NotFound();
            }

            return Ok(listaLibros);

        }

    }
}
