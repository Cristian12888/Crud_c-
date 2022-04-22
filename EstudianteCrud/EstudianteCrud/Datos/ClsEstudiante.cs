using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EstudianteCrud.Modelo;
using System.Windows.Forms;

namespace EstudianteCrud.Datos
{
    internal class ClsEstudiante
    {

        private SqlDataReader leerfilas;

        public  DataTable ListarEstudiante()
        {
            try
            {
                ConexionBD.abrir();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand("ListarEstudiante", ConexionBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                leerfilas = cmd.ExecuteReader();
                dt.Load(leerfilas);
                leerfilas.Close();
                return dt;


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
                return null;

            }finally
            {
                ConexionBD.Cerrar();
            }
        }

        public static bool InsertarEstudiante(Estudiante e)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand cmd = new SqlCommand("InsertarEstudiante", ConexionBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", e.Documento1);
                cmd.Parameters.AddWithValue("@Nombre", e.Nombre1);
                cmd.Parameters.AddWithValue("@Apellido", e.Apellido1);
                cmd.Parameters.AddWithValue("@Edad", e.Edad1);
                cmd.Parameters.AddWithValue("@Correo", e.Correo1);
                cmd.Parameters.AddWithValue("@Telefono", e.Telefono1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
                 
            }finally
            {
                ConexionBD.Cerrar();
            }


        }

        public static Estudiante ConsultarEstudiante(string Documento)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand cmd = new SqlCommand("ConsultarEstudiante", ConexionBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", Documento);
                SqlDataReader dr= cmd.ExecuteReader();
                Estudiante es= new Estudiante();

                if(dr.Read())
                {
                    es.Documento1 = dr["Documento"].ToString();
                    es.Nombre1 = dr["Nombre"].ToString();
                    es.Apellido1 = dr["Apellido"].ToString();
                    es.Edad1 = Convert.ToInt32(dr["Edad"].ToString());
                    es.Correo1 = dr["Correo"].ToString();
                    es.Telefono1 = dr["Telefono"].ToString();
                    return es;
                }else
                {
                    return null;
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return null;
            }
            finally
            {
                ConexionBD.Cerrar();
            }


        }

        public static bool EditarEstudiante(Estudiante e)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand cmd = new SqlCommand("EditarEstudiante", ConexionBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", e.Documento1);
                cmd.Parameters.AddWithValue("@Nombre", e.Nombre1);
                cmd.Parameters.AddWithValue("@Apellido", e.Apellido1);
                cmd.Parameters.AddWithValue("@Edad", e.Edad1);
                cmd.Parameters.AddWithValue("@Correo", e.Correo1);
                cmd.Parameters.AddWithValue("@Telefono", e.Telefono1);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;

            }
            finally
            {
                ConexionBD.Cerrar();
            }


        }

        public static bool EliminarEstudiante(string Documento)
        {
            try
            {
                ConexionBD.abrir();
                SqlCommand cmd = new SqlCommand("EliminarEstudiante", ConexionBD.Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", Documento);
                int can = cmd.ExecuteNonQuery();

                if (can==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
                return false;
            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }


    }
}
