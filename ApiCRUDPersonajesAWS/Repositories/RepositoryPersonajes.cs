using ApiCRUDPersonajesAWS.Data;
using ApiCRUDPersonajesAWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCRUDPersonajesAWS.Repositories
{
    public class RepositoryPersonajes
    {
        private PersonajesContext context;

        public RepositoryPersonajes(PersonajesContext context)
        {
            this.context = context;
        }

        public List<Personaje> GetPersonajes()
        {
            return this.context.Personajes.ToList();
        }

        public Personaje FindPersonaje(int id)
        {
            return this.context.Personajes.SingleOrDefault(x => x.IdPersonaje == id);
        }


        private int GetMaxIdPersonaje()
        {
            if (this.context.Personajes.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Personajes.Max(x => x.IdPersonaje) + 1;
            }
        }
        public void InsertPersonaje(string nombre, string imagen)
        {
            Personaje personaje = new Personaje
            {
                IdPersonaje = this.GetMaxIdPersonaje(),
                Nombre = nombre,
                Imagen = imagen
            };
            this.context.Personajes.Add(personaje);
            this.context.SaveChanges();
        }

        public void ModificarPersonaje(int id, string  nombre, string imagen)
        {
            Personaje personaje = this.FindPersonaje(id);
            personaje.Nombre = nombre;
            personaje.Imagen = imagen;
            this.context.SaveChanges();
        }

        public void EliminarPersonaje(int id)
        {
            Personaje personaje = this.FindPersonaje(id);
            this.context.Personajes.Remove(personaje);
            this.context.SaveChanges();
        }
    }
}
