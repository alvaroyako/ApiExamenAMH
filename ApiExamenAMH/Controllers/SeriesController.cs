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
    public class SeriesController : ControllerBase
    {
        private RepositorySerie repo;

        public SeriesController(RepositorySerie repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Serie>> GetSeries()
        {
            return this.repo.GetSeries();
        }

        [HttpGet("{id}")]
        public ActionResult<Serie> GetSerie(int id)
        {
            return this.repo.FindSerie(id);
        }

        [HttpPost]
        public ActionResult InsertSerie(Serie ser)
        {
            this.repo.InsertarSerie(
                ser.Nombre,
                ser.Imagen,
                ser.Puntuacion,
                ser.Año
                );
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateSerie(Serie ser)
        {
            this.repo.UpdateSerie(
                ser.IdSerie,
                ser.Nombre,
                ser.Imagen,
                ser.Puntuacion,
                ser.Año);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void DeleteSerie(int id)
        {
            this.repo.DeleteSerie(id);
        }

        [HttpGet("[action]/{idserie}")]
        public ActionResult<List<Personaje>> PersonajesSerie(int idserie)
        {
            return this.repo.GetPersonajesSerie(idserie);
        }
    }
}
