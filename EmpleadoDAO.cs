using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormEmpleados
{
    //Data Access Object
    class EmpleadoDAO
    {   
        public int ingresarEmpleado(Empleado empleado)
        {   int resp = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("INSERT INTO tbl_empleados(rut,nombre,apellido,sueldo,codigo_departamento) VALUES ('{0}', '{1}', '{2}', '{3}', {4})", empleado.rut, empleado.nombre, empleado.apellido, empleado.sueldo, empleado.departamento.codigo), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }
        public int modificarEmpleado(Empleado empleado)
        {
            int resp = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            Console.WriteLine(empleado);
            MySqlCommand orden = new MySqlCommand(string.Format("UPDATE tbl_empleados SET nombre='{0}',apellido='{1}', sueldo='{2}', codigo_departamento='{3}' WHERE rut='{4}' ", empleado.nombre, empleado.apellido, empleado.sueldo, empleado.departamento.codigo, empleado.rut), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }
        public int eliminarEmpleado(string rut)
        {
            int resp = 0;
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("DELETE FROM tbl_empleados WHERE rut='{0}' ", rut), conexion);
            resp = orden.ExecuteNonQuery();
            conexion.Close();
            return resp;
        }

        public Empleado buscarEmpleado(string rut)
        {
            Empleado empleado = new Empleado();
            MySqlCommand orden = new MySqlCommand(string.Format("SELECT * FROM tbl_empleados WHERE rut=@rut"), Conexion.abrirConexion());
            orden.Parameters.AddWithValue("@rut",rut);
            MySqlDataReader lector = orden.ExecuteReader();
            if (lector.Read())
            {
                empleado.rut = lector.GetString(0);
                empleado.nombre = lector.GetString(1);
                empleado.apellido = lector.GetString(2);
                empleado.sueldo = lector.GetInt32(4);
            }
            return empleado;
        }

        public static List<Empleado> listarEmpleados()
        {
            List<Empleado> lista = new List<Empleado>();
            MySqlConnection conexion = Conexion.abrirConexion();
            MySqlCommand orden = new MySqlCommand(string.Format("SELECT * FROM tbl_empleados"), conexion);
            MySqlDataReader lector=orden.ExecuteReader();
            while (lector.Read())
            {
                Empleado empleado = new Empleado();
                empleado.rut = lector.GetString(0);
                empleado.nombre = lector.GetString(1);
                empleado.apellido = lector.GetString(2);
                empleado.sueldo = lector.GetInt32(4);
                Departamento departamento = new Departamento();
                departamento.codigo = lector.GetInt32(3);
                empleado.departamento = departamento;
                lista.Add(empleado);
            }

            return lista;
        }



    }
}
