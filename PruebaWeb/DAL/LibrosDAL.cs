using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;

namespace DAL
{
    public class LibrosDAL
    {
        public static List<clsLibro> Obtener()
        {
            List<clsLibro> _lista = new List<clsLibro>();
            using (var _conn = clsConexion.GetConnection())
            {
                string _sql = "Select id, nombre,autor,categoria,descripcion,precio From libro";
                var _command = clsConexion.CreateCommand(_conn, _sql);
                using (var _reader = clsConexion.ExecuteReader(_command))
                {
                    while (_reader.Read())
                    {
                        int _index = -1;
                        clsLibro _libro = new clsLibro();
                        _libro.id = _reader.GetInt32(clsConexion.GetIndexReader(ref _index));
                        _libro.nombre = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _libro.autor = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _libro.categoria = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _libro.descripcion = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _libro.precio = _reader.GetString(clsConexion.GetIndexReader(ref _index));
                        _lista.Add(_libro);
                    }
                }
            }
            return _lista;
        }
    }
}
