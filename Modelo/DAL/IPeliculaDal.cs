using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.ET;

namespace Modelo.DAL
{
    interface IPeliculaDal
    {
        List<Pelicula> Listar();
        Pelicula ObtenerPorId(int id);
        bool Actualizar(Pelicula pelicula);
        Pelicula Agregar(Pelicula pelicula);
        bool Eliminar(int id);
    }
}
