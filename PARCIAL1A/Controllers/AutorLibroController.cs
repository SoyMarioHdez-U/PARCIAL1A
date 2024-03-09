using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorLibroController : ControllerBase
    {

        private readonly librosContext _librosContext;

        public AutorLibroController(librosContext librosContext)
        {
            _librosContext = librosContext;
        }
        [HttpGet]
        [Route("GetAll/")]
        public IActionResult Get()
        {

            List<AutorLibro> listaAutorLibro = (from p in _librosContext.AutorLibro
                                          select p).ToList();

            if (listaAutorLibro == null)
            {
                return NotFound();
            }

            return Ok(listaAutorLibro);

        }

        [HttpGet]
        [Route("GetTodo/")]
        public IActionResult GetTodo()
        {

            var listadeprueba = (from al in _librosContext.AutorLibro

                                 join a in _librosContext.Libros
                                         on al.LibroId equals a.Id
                                 

                                 select new
                                 {
                                     p.Id,
                                     p.Titulo,
                                     p.Contenido,
                                     p.FechaPublicacion,
                                     p.AutorId


                                 }).Take(20).ToList();

            if (listadeprueba.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }
    }
}
