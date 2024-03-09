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

        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] Autores listaClientes)
        {

            try
            {

                _librosContext.Autores.Add(listaClientes);
                _librosContext.SaveChanges();
                return Ok(listaClientes);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);

            }

        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] Autores listaAutoresNueva)
        {

            Autores? listaAutoresActu = (from c in _librosContext.Autores
                                           where c.Id == id
                                           select c).FirstOrDefault();
            if (listaAutoresActu == null)
            {

                return NotFound();

            }

            listaAutoresActu.Id = listaAutoresNueva.Id;
            listaAutoresActu.Nombre = listaAutoresNueva.Nombre;


            _librosContext.Entry(listaAutoresActu).State = EntityState.Modified;
            _librosContext.SaveChanges();

            return Ok(listaAutoresNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {

            Autores? listaAutores = (from c in _librosContext.Autores
                                       where c.Id == id
                                       select c).FirstOrDefault();
            if (listaAutores == null)
            {

                return NotFound();

            }

            _librosContext.Autores.Attach(listaAutores);
            _librosContext.Autores.Remove(listaAutores);
            _librosContext.SaveChanges();

            return Ok(listaAutores);

        }
    }

    

   
}
