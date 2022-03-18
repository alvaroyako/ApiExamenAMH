using ApiExamenAMH.Models;
using ApiExamenAMH.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenAMH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositorySerie repo;

        public PersonajesController(RepositorySerie repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Personaje>> GetPersonajes()
        {
            return this.repo.GetPersonajes();
        }

        [HttpGet("{id}")]
        public ActionResult <Personaje> GetPersonaje(int id)
        {
            return this.repo.FindPersonaje(id);
        }

        [HttpPost]
        public ActionResult InsertPersonaje(Personaje personaje)
        {
            this.repo.InsertarPersonaje(
                personaje.Nombre,
                personaje.Imagen,
                personaje.IdSerie
                );
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdatePersonaje(Personaje pj)
        {
            this.repo.UpdatePersonaje(
                pj.IdPersonaje,
                pj.Nombre,
                pj.Imagen);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeletePersonaje(int id)
        {
            this.repo.DeletePersonaje(id);
        }

        [HttpPut("[action]/{id}/{idserie}")]
        public ActionResult UpdatePersonajeSerie(int id, int idserie)
        {
            this.repo.UpdatePersonajeSerie(
                id,
                idserie
                );
            return Ok();
        }
    }
}
