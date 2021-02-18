using System;
using System.Collections.Generic;
using System.Text;

namespace Ent
{
    public class clsCliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public  DateTime fechaNac { get; set; }
        public  string direccion { get; set; }
        public  int telefono { get; set; }
        public  string email { get; set; }
    }
    public class clsRegistro
    {
        public  int id { get; set; }
        public  string nombreLibro { get; set; }
        public  string autor { get; set; }
        public  string nombreCliente { get; set; }
        public string emailCliente { get; set; }
    }
}
