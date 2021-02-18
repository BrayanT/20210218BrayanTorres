using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ent;
using DAL;

namespace BL
{
    public class ClienteBL
    {
        public int Guardar(clsCliente pCliente)
        {
            return ClienteDAL.Guardar(pCliente);
        }

        public int Modificar(clsCliente pCliente)
        {
            return ClienteDAL.Modificar(pCliente);
        }

        public int Eliminar(int id)
        {
            return ClienteDAL.Eliminar(id);
        }

        public List<clsCliente> Obtener()
        {
            return ClienteDAL.Obtener();
        }
        public int guardarRegistro(clsRegistro pRegistro)
        {
            return ClienteDAL.Registrar(pRegistro);
        }
    }
}
