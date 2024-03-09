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

            Autores? listaAutores = (from p in _librosContext.Autores
                                     select p).FirstOrDefault();

            if (listaAutores == null)
            {
                return NotFound();
            }

            return Ok(listaAutores);

        }
    }

    

   
}
