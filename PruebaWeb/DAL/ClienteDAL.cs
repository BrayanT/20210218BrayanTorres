using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ent;

namespace DAL
{
    public class ClienteDAL
    {
        public static int Guardar(clsCliente pCliente)
        {
            var _result = 0;
            using (var _conn = clsConexion.GetConnection())
            {
                string _sql = @"Insert into Cliente(nombre,apellido,fechaNac,direccion,telefono,email) values(@nombre,@apellido,@fechaNac,@direccion,@telefono,@email)";
                var _command = clsConexion.CreateCommand(_conn, _sql);
                clsConexion.CreateParameter(ref _command, "nombre", pCliente.nombre);
                clsConexion.CreateParameter(ref _command, "apellido", pCliente.apellido);
                clsConexion.CreateParameter(ref _command, "fechaNac", pCliente.fechaNac);
                clsConexion.CreateParameter(ref _command, "direccion", pCliente.direccion);
                clsConexion.CreateParameter(ref _command, "telefono", pCliente.telefono);
                clsConexion.CreateParameter(ref _command, "email", pCliente.email);
                _result = clsConexion.ExecuteCommand(_command);
            }
            return _result;
        }


    }
}
