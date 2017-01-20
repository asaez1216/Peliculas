using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.ET;
using System.Configuration;

namespace Modelo.DAL
{
    class PeliculaDalImp:IPeliculaDal
    {
        public List<Pelicula> Listar()
        {
            var peliculas = new List<Pelicula>();
            
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Presupuesto_corriente"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM peliculas", con);
                    using (var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            // Usuario
                            var pelicula = new Pelicula
                            {
                                PeliculaId = Convert.ToInt32(dr["peliculaId"]),
                                NombrePelicula = dr["nombrePelicula"].ToString(),
                                NombreDirector = dr["nombreDirector"].ToString(),
                                AcnoEstreno = Convert.ToInt32(dr["saldo"])

                            };

                            // Agregamos el usuario a la lista genreica
                            peliculas.Add(pelicula);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }

            return peliculas;
        }


    }
    }
}
