using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormEmpleados
{
    public class Conexion
    {
        public static MySqlConnection abrirConexion()
        {
            MySqlConnection conexion = new MySqlConnection("server=127.0.0.1; database=BD_Empleados;Uid=root;pwd=;");
            conexion.Open();
            return conexion;
        }
    }
}
