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

        public static int Modificar(clsCliente pCliente)
        {
            var _result = 0;
            using (var _conn = clsConexion.GetConnection())
            {
                string _sql = @"Update Cliente set nombre=@nombre, apellido=@apellido, fechaNac=@fechaNac, direccion=@direccion, telefono=@telefono, email=@email where id=@id";
                var _command = clsConexion.CreateCommand(_conn, _sql);
                clsConexion.CreateParameter(ref _command, "nombre", pCliente.nombre);
                clsConexion.CreateParameter(ref _command, "apellido", pCliente.apellido);
                clsConexion.CreateParameter(ref _command, "fechaNac", pCliente.fechaNac);
                clsConexion.CreateParameter(ref _command, "direccion", pCliente.direccion);
                clsConexion.CreateParameter(ref _command, "telefono", pCliente.telefono);
                clsConexion.CreateParameter(ref _command, "email", pCliente.email);
                clsConexion.CreateParameter(ref _command, "id", pCliente.id);
                _result = clsConexion.ExecuteCommand(_command);
            }
            return _result;
        }

        public static int Eliminar(int id)
        {
            var _result = 0;
            using (var _conn = clsConexion.GetConnection())
            {
                string _sql = @"Delete From Cliente where id=@id";
                var _command = clsConexion.CreateCommand(_conn, _sql);
                clsConexion.CreateParameter(ref _command, "id", id);
                _result = clsConexion.ExecuteCommand(_command);

            }
            return _result;
        }
        public static List<clsCliente> Obtener()
        {
            List<clsCliente> _lista = new List<clsCliente>();
            using (var _conn = clsConexion.GetConnection())
            {
                string _sql = "Select id, nombre,apellido,fechaNac,direccion,telefono,email From Cliente";
                var _command = clsConexion.CreateCommand(_conn, _sql);
                using (var _reader = clsConexion.ExecuteReader(_command))
                {
                    while (_reader.Read())
                    {
                        int _index = -1;
                        clsCliente _Cliente = new clsCliente();
                        _Cliente.id = _reader.GetInt32(clsConexion.GetIndexReader(ref _index));
                        _Cliente.nombre = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _Cliente.apellido = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _Cliente.fechaNac = _reader.GetDateTime(clsConexion.GetIndexReader(ref _index));
                        _Cliente.direccion = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _Cliente.telefono = _reader.GetInt32(clsConexion.GetIndexReader(ref _index));
                        _Cliente.email = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _lista.Add(_Cliente);
                    }
                }
            }
            return _lista;
        }

        public static int Registrar(clsRegistro pRegistro)
        {
            var _result = 0;
            using (var _conn = clsConexion.GetConnection())
            {
                string _sql = @"Insert into Registro(nombreLibro,autor,nombreCliente,emailCliente) values(@libro,@autor,@cliente,@email)";
                var _command = clsConexion.CreateCommand(_conn, _sql);
                clsConexion.CreateParameter(ref _command, "libro", pRegistro.nombreLibro);
                clsConexion.CreateParameter(ref _command, "autor", pRegistro.autor);
                clsConexion.CreateParameter(ref _command, "cliente", pRegistro.nombreCliente);
                clsConexion.CreateParameter(ref _command, "email", pRegistro.emailCliente);
                _result = clsConexion.ExecuteCommand(_command);
            }
            return _result;
        }
    }
}
