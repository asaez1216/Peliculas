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
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Pelicula"].ToString()))
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
                                AcnoEstreno = Convert.ToInt32(dr["acnoEstreno"])

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


        public Pelicula ObtenerPorId(int id)
        {


            var pelicula = new Pelicula();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Pelicula"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("SELECT * FROM peliculas WHERE peliculaId = @id", con);
                    query.Parameters.AddWithValue("@id", id);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            pelicula.PeliculaId = Convert.ToInt32(dr["peliculaId"]);
                            pelicula.NombrePelicula = dr["nombrePelicula"].ToString();
                            pelicula.NombreDirector = dr["nombreDirector"].ToString();
                            pelicula.AcnoEstreno = Convert.ToInt32(dr["acnoEstreno"]);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return pelicula;

        }


        public bool Actualizar(Pelicula pelicula)
        {

            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Pelicula"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("UPDATE pelicula SET nombrePelicula = @p0, nombreDirector = @p1,acnoEstreno=@p2 WHERE pelicula = @p3", con);

                    query.Parameters.AddWithValue("@p0", pelicula.NombrePelicula);
                    query.Parameters.AddWithValue("@p1", pelicula.NombreDirector);
                    query.Parameters.AddWithValue("@p2", pelicula.AcnoEstreno);
                    query.Parameters.AddWithValue("@p3",pelicula.PeliculaId);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

        public Pelicula Agregar(Pelicula pelicula)
        {

           
            var peliculaAgregada = new Pelicula();

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Pelicula"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("INSERT INTO peliculas(nombrePelicula, nombreDirector, acnoEstreno) VALUES (@p0, @p1, @p2); Select * From peliculas where peliculaid=Scope_Identity();", con);

                    query.Parameters.AddWithValue("@p0", pelicula.NombrePelicula);
                    query.Parameters.AddWithValue("@p1", pelicula.NombreDirector);
                    query.Parameters.AddWithValue("@p2", pelicula.AcnoEstreno);

                    using (var dr = query.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            peliculaAgregada.PeliculaId = Convert.ToInt32(dr["peliculaId"]);
                            peliculaAgregada.NombrePelicula = dr["nombrePelicula"].ToString();
                            peliculaAgregada.NombreDirector = dr["nombreDirector"].ToString();
                            peliculaAgregada.AcnoEstreno = Convert.ToInt32(dr["acnoEstreno"]);

                        }
                    }

                    
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return peliculaAgregada;

        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;

            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Pelicula"].ToString()))
                {
                    con.Open();

                    var query = new SqlCommand("DELETE FROM peliculas WHERE peliculaId= @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();

                    respuesta = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return respuesta;
        }

      }

  }
  