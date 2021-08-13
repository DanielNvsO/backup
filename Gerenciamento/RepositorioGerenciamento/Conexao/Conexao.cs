using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Repositorio.Conexao
{
    
    public class Conexao
    {
        public string _connectionString = @"Data Source=dbinstance1.cm6tphlcavn2.sa-east-1.rds.amazonaws.com,1433;Initial Catalog=Consulta01;User ID=admin;Password=Familia1no";

        SqlConnection sqlCon = null;

        public SqlConnection GetConnection()
        {
            sqlCon = new SqlConnection(_connectionString);

            sqlCon.Open();

            return sqlCon;
        }


    }
}
