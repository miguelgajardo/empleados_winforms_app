using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace WinFormEmpleados
{
    internal class DepartamentoDAO
    {
        public int crearDepartamento(Departamento departamento)
        {
            int resp = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("INSERT INTO tbl_departamentos(codigo_departamento,nombre_departamento) VALUES ('{0}', '{1}')", departamento.codigo, departamento.nombre), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }

        public static Departamento buscarDepartamento(string codigo)
        {
            Departamento departamento = new Departamento();
            MySqlCommand orden = new MySqlCommand(string.Format("SELECT * FROM tbl_departamentos WHERE codigo_departamento=@codigo"), Conexion.abrirConexion());
            orden.Parameters.AddWithValue("@codigo", codigo);
            MySqlDataReader lector = orden.ExecuteReader();
            if (lector.Read())
            {
                departamento.codigo = lector.GetInt32(0);
                departamento.nombre = lector.GetString(1);
            }
            return departamento;
        }

        public static List<Departamento> listarDepartamentos()
        {
            List<Departamento> lista = new List<Departamento>();
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("SELECT * FROM tbl_departamentos"), conexion);
            MySqlDataReader lector = orden.ExecuteReader();
            while (lector.Read())
            {
                Departamento departamento = new Departamento();
                departamento.codigo = lector.GetInt32(0);
                departamento.nombre = lector.GetString(1);
                lista.Add(departamento);
            }
            return lista;
        }

        public int modificarDepartamento(Departamento departamento)
        {
            int resp = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("UPDATE tbl_departamentos SET nombre_departamento='{0}' WHERE codigo_departamento='{1}' ", departamento.nombre, departamento.codigo), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }

        public int eliminarDepartamento(string codigo)
        {
            int resp = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("DELETE FROM tbl_departamentos WHERE codigo_departamento='{0}' ", codigo), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }
    }
}