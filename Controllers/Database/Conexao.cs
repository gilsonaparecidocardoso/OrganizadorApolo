using OrganizadorApolo.Models;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorApolo.Controllers.Database
{
    public class Conexao
    {
        private readonly SqlConnection sqlConn;

        public Conexao()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_string_sql"].ConnectionString);
        }

        //public List<MGenero> RetornarGeneros()
        //{
        //    List<MGenero> gens = new List<MGenero>();

        //    using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
        //    {
        //        connection.Open();
        //        string query = "SELECT idGenero, descricaoGenero FROM TBGenero";
        //        using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    gens.Add(new MGenero(reader.GetInt32(0), reader.GetString(1)));
        //                }
        //            }
        //        }
        //    }

        //    return gens;
        //}

        //private SqlCommand RetornaGeneros(string _sqlCommand)
        //{
        //    SqlCommand cmd = new SqlCommand(_sqlCommand);
        //    cmd.CommandType = CommandType.Text;
        //    cmd.Connection = sqlConn;

        //    sqlConn.Open();
        //    return cmd;
        //}
    }
}
