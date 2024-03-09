using Microsoft.AspNetCore.Mvc;
using PARCIAL1A.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PARCIAL1A.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class postsController : ControllerBase
    {

        private readonly librosContext _librosContext;

        public postsController(librosContext librosContext)
        {

            _librosContext = librosContext;

        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get() 
        {
            
            List<Posts> listadeprueba = (from p in _librosContext.Posts
                                          select p).ToList();

            if(listadeprueba.Count() == 0) 
            {
                return NotFound();
            }

            return Ok(listadeprueba);
        
        }

        [HttpGet]
        [Route("GetId/{id}")]
        public IActionResult Buscar(string id)
        {

            Posts? listadeprueba = (from p in _librosContext.Posts
                                         where p.id == id
                                         select p).FirstOrDefault();

            if (listadeprueba == null)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }


        [HttpGet]
        [Route("GetPruebaDeRelacion")]
        public IActionResult GetDatosR()
        {

            List<Datos> listadeprueba = (from d in _pruebaContext.Datos

                                         join su in _pruebaContext.Summero
                                                 on d.id_adios equals su.id_adios

                                         join s in _pruebaContext.Star
                                                on d.id_que equals s.id_que

                                         select d).ToList();

            if (listadeprueba.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }
        [HttpGet]
        [Route("GetTodo")]
        public IActionResult GetTodo()
        {

           var listadeprueba = (from d in _pruebaContext.Datos

                                         join su in _pruebaContext.Summero
                                                 on d.id_adios equals su.id_adios

                                         join s in _pruebaContext.Star
                                                on d.id_que equals s.id_que

                                         select new 
                                         {
                                         d.id_hola,
                                         d.letra,
                                         d.numero,
                                         d.doble,
                                         d.fecha,
                                         adiositoID = d.id_adios, // Si un nombre de las variables es igual al nombre de una tabla se puede hacer esto 
                                         su.tal,
                                         su.byebye,
                                         QUEEEEE = d.id_que,
                                         s.Que,
                                         s.Como,
                                         s.Cuando,
                                         s.Porque,
                                         SumaDeIDs = $"Hola: {d.id_hola}, Adios: {su.id_adios}, Que: {s.id_que}" // Tambien se pueden unir varias variables
                                         
                                         }).ToList();

            if (listadeprueba.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }

        [HttpGet]
        [Route("GetConSalto")]
        public IActionResult GetSaltos()
        {

            var listadeprueba = (from d in _pruebaContext.Datos

                                 join su in _pruebaContext.Summero
                                         on d.id_adios equals su.id_adios

                                 join s in _pruebaContext.Star
                                        on d.id_que equals s.id_que

                                 select new
                                 {
                                     d.id_hola,
                                     d.letra,
                                     d.numero,
                                     d.doble,
                                     d.fecha,
                                     adiositoID = d.id_adios, // Si un nombre de las variables es igual al nombre de una tabla se puede hacer esto 
                                     su.tal,
                                     su.byebye,
                                     QUEEEEE = d.id_que,
                                     s.Que,
                                     s.Como,
                                     s.Cuando,
                                     s.Porque,
                                     SumaDeIDs = $"Hola: {d.id_hola}, Adios: {su.id_adios}, Que: {s.id_que}" // Tambien se pueden unir varias variables

                                 }).Take(1).ToList(); // take(1) nos dara el top, con skip(10) nos quitara 10 registros  y OrderBy(condicion => condicion.variable que se quiere ordenar), se le puede agregar más de una con ThenBy y la misma estructura

            if (listadeprueba.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadeprueba);
        }






        [HttpPost]
        [Route("Post")]
        public IActionResult Guardar([FromBody] Posts listadeprueba)
        {

            try
            {

                _librosContext.Posts.Add(listadeprueba);
                _librosContext.SaveChanges();
                return Ok(listadeprueba);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Update(int id, [FromBody] Posts listadepruebaNueva)
        {
            Posts? listadeprueba = (from p in _librosContext.Posts // Al mismo modo, en la busqueda se le puede poner el ? para dar a entender que puede dar nulo y mostrara un resultado vacio
                                     where p.id == id
                                     select p).FirstOrDefault();
            if (listadeprueba == null)
            {

                return NotFound();

            }

            listadeprueba.tal = listadepruebaNueva.tal;
            listadeprueba.byebye = listadepruebaNueva.byebye;

            _pruebaContext.Entry(listadeprueba).State = EntityState.Modified;
            _pruebaContext.SaveChanges();

            return Ok(listadepruebaNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            Summer? listadeprueba = (from s in _pruebaContext.Summero // Al mismo modo, en la busqueda se le puede poner el ? para dar a entender que puede dar nulo y mostrara un resultado vacio
                                     where s.id_adios == id
                                     select s).FirstOrDefault();
            if (listadeprueba == null)
            {

                return NotFound();

            }

            _pruebaContext.Summero.Attach(listadeprueba);
            _pruebaContext.Summero.Remove(listadeprueba);
            _pruebaContext.SaveChanges();

            return Ok(listadeprueba);


        }

    }


    

    
}
