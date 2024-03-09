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
        [Route("GetAutorLibro/")]
        public IActionResult GetLibros()
        {

            var listadeprueba = (from a in _librosContext.Autores

                                 join au in _librosContext.AutorLibro
                                         on a.Id equals au.AutorId
                                 join l in _librosContext.Libros
                                         on au.LibroId equals l.Id

                                 select new
                                 {
                                     Autor = a.Nombre,
                                     Libro = l.Titulo,

                                 }).ToList();

            if (listadeprueba.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }
    }
}
