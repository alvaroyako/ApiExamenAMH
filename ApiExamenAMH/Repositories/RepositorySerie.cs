using ApiExamenAMH.Data;
using ApiExamenAMH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiExamenAMH.Repositories
{
    public class RepositorySerie
    {
        private SerieContext context;

        public RepositorySerie(SerieContext context)
        {
            this.context = context;
        }

        #region SERIES
        private int GetMaxIdSeries()
        {
            if (this.context.Series.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Series.Max(z => z.IdSerie) + 1;
            }
        }

        public List<Serie> GetSeries()
        {
            return this.context.Series.ToList();
        }

        public Serie FindSerie(int id)
        {
            return this.context.Series.FirstOrDefault(x => x.IdSerie == id);
        }

        public void InsertarSerie(string nombre, string imagen, double puntuacion,int año)
        {
            Serie ser = new Serie();
            int idserie = this.GetMaxIdSeries();
            ser.IdSerie = idserie;
            ser.Nombre = nombre;
            ser.Imagen = imagen;
            ser.Puntuacion = puntuacion;
            ser.Año = año;
            this.context.Series.Add(ser);
            this.context.SaveChanges();
        }

        public void UpdateSerie(int idserie, string nombre, string imagen, double puntuacion, int año)
        {
            Serie ser = this.FindSerie(idserie);
            ser.Nombre = nombre;
            ser.Imagen = imagen;
            ser.Puntuacion = puntuacion;
            ser.Año = año;
            this.context.SaveChanges();
        }

        public void DeleteSerie(int idserie)
        {
            Serie ser = this.FindSerie(idserie);
            this.context.Series.Remove(ser);
            this.context.SaveChanges();
        }

        public List<Personaje> GetPersonajesSerie(int idserie)
        {
            var consulta = from datos in this.context.Personajes
                           where datos.IdSerie == idserie
                           select datos;
            return consulta.ToList();
        }

        #endregion

        #region PERSONAJES

        private int GetMaxIdPersonajes()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(z => z.IdPersonaje) + 1;
            }
        }

        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.context.Personajes.FirstOrDefault(x => x.IdPersonaje == id);
        }

        public void InsertarPersonaje(string nombre,string imagen,int idserie)
        {
            Personaje pj = new Personaje();
            int idpersonaje = this.GetMaxIdPersonajes();
            pj.IdPersonaje = idpersonaje;
            pj.Nombre = nombre;
            pj.Imagen = imagen;
            pj.IdSerie = idserie;
            this.context.Personajes.Add(pj);
            this.context.SaveChanges();
        }

        public void UpdatePersonaje(int idpersonaje, string nombre, string imagen)
        {
            Personaje pj = this.FindPersonaje(idpersonaje);
            pj.Nombre = nombre;
            pj.Imagen = imagen;
            this.context.SaveChanges();
        }

        public void DeletePersonaje(int idpersonaje)
        {
            Personaje pj = this.FindPersonaje(idpersonaje);
            this.context.Personajes.Remove(pj);
            this.context.SaveChanges();
        }

        public void UpdatePersonajeSerie(int idpersonaje, int idserie)
        {
            Personaje pj = this.FindPersonaje(idpersonaje);
            pj.IdSerie = idserie;
            this.context.SaveChanges();
        }
        #endregion

    }
}
