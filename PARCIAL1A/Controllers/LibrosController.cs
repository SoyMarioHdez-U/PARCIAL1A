using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] Autores listaLibros)
        {

            try
            {

                _librosContext.Autores.Add(listaLibros);
                _librosContext.SaveChanges();
                return Ok(listaLibros);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] Libros listaLibrosNueva)
        {

            Libros? listaLibrosActu = (from c in _librosContext.Libros
                                         where c.Id == id
                                         select c).FirstOrDefault();
            if (listaLibrosActu == null)
            {

                return NotFound();

            }

            listaLibrosActu.Id = listaLibrosNueva.Id;
            listaLibrosActu.Titulo = listaLibrosNueva.Titulo;


            _librosContext.Entry(listaLibrosActu).State = EntityState.Modified;
            _librosContext.SaveChanges();

            return Ok(listaLibrosNueva);


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
