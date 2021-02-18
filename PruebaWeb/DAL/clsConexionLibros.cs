using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class clsConexionLibros
    {
        static TypeProvider m_TypeProvider = TypeProvider.SQLSERVER;

        //creamos el string de conexion segun el gestor a utilizar
        const string m_StrConnection = @"Data Source=.;Initial Catalog=Libros;Integrated Security=True";
        //obtener una conexion generica y se retorna una conexion abierta
        public static IDbConnection GetConnection()
        {
            IDbConnection _conn = null;
            if (TypeProvider.SQLSERVER == m_TypeProvider)
            {
                _conn = new SqlConnection(m_StrConnection);
            }
            _conn.Open();
            return _conn;
        }
        //ejecucion de los comandos de la BD
        public static int ExecuteCommand(IDbCommand pComand)
        {
            return pComand.ExecuteNonQuery();
        }
        //se ejecuta una transaccion donde cada comando enviado se ejecuta kmo uno solo
        public static int ExecuteTransationCommand(IDbConnection pconn, ICollection<IDbCommand> pComands)
        {
            int _result = 0;
            IDbTransaction _transaction = pconn.BeginTransaction();
            try
            {
                foreach (var item in pComands)
                {
                    item.Connection = pconn;
                    item.Transaction = _transaction;
                    _result = clsConexion.ExecuteCommand(item);
                }
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                _result = 0;
            }
            return _result;
        }
        //crear una lista de comandos para enviar en la transaccion
        public static ICollection<IDbCommand> CreateCollectionComand()
        {
            return new List<IDbCommand>();
        }
        //ejecuta un comando de tipo reader el cual devuelve los datos dependiendo el tipo de consulta
        public static IDataReader ExecuteReader(IDbCommand pComando)
        {
            return pComando.ExecuteReader();
        }
        //crea un comando generico para cualquier tipo de datos
        public static IDbCommand CreateCommand(IDbConnection pconn, string pSql)
        {
            IDbCommand _comand = pconn.CreateCommand();
            _comand.CommandText = pSql;
            _comand.Connection = pconn;
            return _comand;
        }
        //crea un parametro de datos(generico)
        public static void CreateParameter(ref IDbCommand pComando, string pParametro, object pValue)
        {
            IDataParameter _parametro = pComando.CreateParameter();
            _parametro.ParameterName = pParametro;
            _parametro.Value = pValue;
            pComando.Parameters.Add(_parametro);
        }
        //obtiene un index para hacer mas facil el reader
        public static int GetIndexReader(ref int pIndex)
        {
            pIndex = pIndex + 1;
            return pIndex;
        }

    }
}