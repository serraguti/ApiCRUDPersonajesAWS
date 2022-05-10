using ApiCRUDPersonajesAWS.Models;
using ApiCRUDPersonajesAWS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCRUDPersonajesAWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryPersonajes repo;

        public PersonajesController(RepositoryPersonajes repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> Get()
        {
            return this.repo.GetPersonajes();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult<List<Personaje>> BuscarPersonajes(int id)
        {
            return this.repo.GetPersonajes();
        }

        [HttpGet("{id}")]
        public ActionResult<Personaje> Find(int id)
        {
            return this.repo.FindPersonaje(id);
        }

        [HttpPost]
        public ActionResult Create(Personaje personaje)
        {
            this.repo.InsertPersonaje(personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpPut]
        public ActionResult Edit(Personaje personaje)
        {
            this.repo.ModificarPersonaje(personaje.IdPersonaje
                , personaje.Nombre, personaje.Imagen);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            this.repo.EliminarPersonaje(id);
            return Ok();
        }
    }
}
