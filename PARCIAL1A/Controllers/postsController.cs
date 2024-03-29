﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Buscar(int id)
        {
            
            Posts? listadeprueba = (from p in _librosContext.Posts
                                         where p.Id == id
                                         select p).FirstOrDefault();

            if (listadeprueba == null)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }


        [HttpGet]
        [Route("GetLibroAutor/{nombre}")]
        public IActionResult GetTodo(string nombre)
        {

            var listadeprueba = (from p in _librosContext.Posts

                                 join a in _librosContext.Autores
                                         on p.Id equals a.Id
                                 where a.Nombre == nombre

                                 select new
                                 {
                                     p.Id,
                                     p.Titulo,
                                     p.Contenido,
                                     p.FechaPublicacion,
                                     a.Nombre


                                 }).OrderByDescending(item => item.Id).Take(20).ToList();

            if (listadeprueba.Count() == 0)
            {
                return NotFound();
            }

            return Ok(listadeprueba);

        }

        [HttpGet]
        [Route("GetLibros/{libro}")]
        public IActionResult GetLibros(string libro)
        {

            var listadeprueba = (from p in _librosContext.Posts

                                 join a in _librosContext.Autores
                                         on p.Id equals a.Id
                                 join au in _librosContext.AutorLibro
                                         on a.Id equals au.AutorId
                                 join l in _librosContext.Libros
                                         on au.LibroId equals l.Id
                                 where l.Titulo == libro

                                 select new
                                 {
                                     p.Id,
                                     p.Titulo,
                                     p.Contenido,
                                     p.FechaPublicacion,
                                     a.Nombre


                                 }).ToList();

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
                                     where p.Id == id
                                     select p).FirstOrDefault();
            if (listadeprueba == null)
            {

                return NotFound();

            }

            listadeprueba.Titulo = listadepruebaNueva.Titulo;
            listadeprueba.Contenido = listadepruebaNueva.Contenido;
            listadeprueba.FechaPublicacion = listadepruebaNueva.FechaPublicacion;
            listadeprueba.AutorId = listadepruebaNueva.AutorId;

            _librosContext.Entry(listadeprueba).State = EntityState.Modified;
            _librosContext.SaveChanges();

            return Ok(listadepruebaNueva);


        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            Posts? listadeprueba = (from p in _librosContext.Posts // Al mismo modo, en la busqueda se le puede poner el ? para dar a entender que puede dar nulo y mostrara un resultado vacio
                                     where p.Id == id
                                     select p).FirstOrDefault();
            if (listadeprueba == null)
            {

                return NotFound();

            }

            _librosContext.Posts.Attach(listadeprueba);
            _librosContext.Posts.Remove(listadeprueba);
            _librosContext.SaveChanges();

            return Ok(listadeprueba);


        }

    }


    

    
}
