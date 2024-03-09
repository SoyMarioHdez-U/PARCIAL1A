using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] AutorLibro listaAutorLibro)
        {

            try
            {

                _librosContext.AutorLibro.Add(listaAutorLibro);
                _librosContext.SaveChanges();
                return Ok(listaAutorLibro);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] AutorLibro listaAutorLibroNueva)
        {

            AutorLibro? listaLibrosActu = (from c in _librosContext.AutorLibro
                                           where c.AutorId == id
                                           select c).FirstOrDefault();
            if (listaLibrosActu == null)
            {

                return NotFound();

            }

            listaLibrosActu.AutorId = listaAutorLibroNueva.AutorId;
            listaLibrosActu.LibroId = listaAutorLibroNueva.LibroId;
            listaLibrosActu.Orden = listaAutorLibroNueva.Orden;


            _librosContext.Entry(listaLibrosActu).State = EntityState.Modified;
            _librosContext.SaveChanges();

            return Ok(listaAutorLibroNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            Libros? listaLibros = (from c in _librosContext.Libros
                                   where c.Id == id
                                   select c).FirstOrDefault();
            if (listaLibros == null)
            {

                return NotFound();

            }

            _librosContext.Libros.Attach(listaLibros);
            _librosContext.Libros.Remove(listaLibros);
            _librosContext.SaveChanges();

            return Ok(listaLibros);

        }
    }
}
