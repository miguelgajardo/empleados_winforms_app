using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace WinFormEmpleados
{
    internal class Departamento
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
      
        public Departamento() { }
        public Departamento(int codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }
    }
}
