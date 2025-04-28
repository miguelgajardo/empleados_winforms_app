using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormEmpleados
{
    class Empleado
    {   public string rut{ get;set;}
        public string nombre { get; set; }
        public string apellido { get; set; }

        public int sueldo { get; set; }

        public Departamento departamento { get; set; }

        public Empleado() {}
        public Empleado(string rut,string nombre,string apellido,int sueldo, Departamento departamento) {
            this.rut = rut;
            this.nombre=nombre;
            this.apellido=apellido;
            this.sueldo = sueldo;
            this.departamento = departamento;
         }
    }
}