using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Modelo.BAL;
using Modelo.ET;

namespace Peliculas.Controllers
{
    public class PeliculaController : ApiController
    {

        // aqui definimos el modelo

        PeliculaBalImp peliculaBal = new Modelo.BAL.PeliculaBalImp();

        // GET: api/Pelicula
        public IEnumerable<Pelicula> Get()
        {
            return peliculaBal.Listar();
        }

        // GET: api/Pelicula/5
        public Pelicula Get(int id)
        {
            return peliculaBal.ObtenerPorId(id);
        }

        // POST: api/Pelicula
        // crear
        
        public void Post(Pelicula pelicula)
        {
            peliculaBal.Agregar(pelicula);
            
        }

        // PUT: api/Pelicula
        // actualizar
        public void Put(Pelicula pelicula)
        {

            peliculaBal.Actualizar(pelicula);

        }

        // DELETE: api/Pelicula/5
        public void Delete(int id)
        {

            peliculaBal.Eliminar(id);
        }
    }
}
