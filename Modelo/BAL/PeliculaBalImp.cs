using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.DAL;
using Modelo.ET;

namespace Modelo.BAL
{
    public class PeliculaBalImp:IPeliculaBal
    {
        private IPeliculaDal peliculaDalImp = new PeliculaDalImp();

        public List<Pelicula> Listar()
        {
            return peliculaDalImp.Listar();
        }

        public Pelicula ObtenerPorId(int id)
        {
            return peliculaDalImp.ObtenerPorId(id);
        }

        public bool Actualizar(Pelicula pelicula)
        {
            return peliculaDalImp.Actualizar(pelicula);
        }

        public Pelicula Agregar(Pelicula pelicula)
        {
            return peliculaDalImp.Agregar(pelicula);
        }


        public bool Eliminar(int id)
        {

            return peliculaDalImp.Eliminar(id);

        }
    }
}
