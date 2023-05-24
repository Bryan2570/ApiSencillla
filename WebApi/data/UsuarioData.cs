using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.data
{
    public class UsuarioData
    {

        public static bool Registrar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", oUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@Nombres", oUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("@Ciudad", oUsuario.Ciudad);
                cmd.Parameters.AddWithValue("@FechaRegistro", oUsuario.FechaRegistro);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }


        public static bool Modificar(Usuario oUsuario)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", oUsuario.IdUsuario);
                cmd.Parameters.AddWithValue("@DocumentoIdentidad", oUsuario.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@Nombres", oUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", oUsuario.Telefono);
                cmd.Parameters.AddWithValue("@Correo", oUsuario.Correo);
                cmd.Parameters.AddWithValue("@Ciudad", oUsuario.Ciudad);
                cmd.Parameters.AddWithValue("@FechaRegistro", oUsuario.FechaRegistro);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }



        public static List<Usuario> Listar()
        {
            List<Usuario> oListaUsuario = new List<Usuario>();

            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    //md.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oListaUsuario.Add(new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombre = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            });
                        }
                    }
                    return oListaUsuario;
                }
                catch (Exception ex)
                {
                    return oListaUsuario;
                }
            }
        }


        public static Usuario Obtener(int idUsuario)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    oConexion.Open();
                    //cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombre = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            };
                        }
                    }
                    return oUsuario;
                }
                catch (Exception)
                {
                    return oUsuario;
                }
            }

        }


        public static bool Eliminar(int id)
        {
            Usuario oUsuario = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


    }
}