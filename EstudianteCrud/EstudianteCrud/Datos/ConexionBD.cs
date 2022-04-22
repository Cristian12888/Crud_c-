using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EstudianteCrud.Datos
{
    internal class ConexionBD
    {
        public static string CadenaConexion = "Server=DESKTOP-BPQJG8P; DataBase=Estudiantes; Integrated Security=true";

        public static SqlConnection Conexion = new SqlConnection(CadenaConexion);

        public static void abrir()
        {
            if(Conexion.State == ConnectionState.Closed)
            {
                Conexion.Open();
            }
        }

        public static void Cerrar()
        {
            if (Conexion.State == ConnectionState.Open)
            {
                Conexion.Close();
            }
        }



    }
}
