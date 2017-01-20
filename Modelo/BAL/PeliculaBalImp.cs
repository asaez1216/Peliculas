using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.DAL;
using Modelo.ET;

namespace Modelo.BAL
{
    class PeliculaBalImp:IPeliculaBal
    {
        private IPeliculaDal peliculaDalImp = new PeliculaDalImp();

        public List<Pelicula> Listar()
        {
            return peliculaDalImp.Listar();
        }
    }
}
