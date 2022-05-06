using OrganizadorApolo.Controllers.Log;
using OrganizadorApolo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace OrganizadorApolo.Controllers.Database
{
    public class GeneroDAO
    {
        private readonly SqlConnection sqlConn;

        public GeneroDAO()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_string_sql"].ConnectionString);
        }

        public List<MGenero> RetornaTodosGeneros()
        {
            StringBuilder query = new StringBuilder();
            List<MGenero> gens = new List<MGenero>();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT idGenero, descricaoGenero ");
                    query.Append("FROM TBGenero");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gens.Add(new MGenero(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        return gens;
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query.ToString() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return gens;
        }

        /// <summary>
        /// Enviar 4, 56, 5
        /// </summary>
        /// <param name="_generos"></param>
        /// <returns></returns>
        internal List<MGenero> RetornaIdPorGenero(string[] _generos)
        {
            StringBuilder query = new StringBuilder();
            List<MGenero> gens = new List<MGenero>();

            try
            {
                string generos = "";
                foreach (var item in _generos)
                {
                    generos += item + ", ";
                }
                generos = generos.Substring(0, generos.Length - 2);

                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT idGenero, descricaoGenero ");
                    query.Append("FROM TBGenero ");
                    query.Append("WHERE descricaoGenero IN ('").Append(generos).Append("')");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                gens.Add(new MGenero(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                        return gens;
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query.ToString() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return gens;
        }
        
        /// <summary>
        /// Procura por id da tabela TBGeneroFaixa
        /// </summary>
        /// <param name="generoId"></param>
        /// <returns></returns>
        public List<MGenero> RetornaGenerosPorId(int generoId)
        {
            StringBuilder query = new StringBuilder();
            List<MGenero> generos = new List<MGenero>();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT gen.idGenero, gen.descricaoGenero ");
                    query.Append("FROM TBGeneroFaixa gef ");
                    query.Append("INNER JOIN TBGenero gen ON gen.idGenero = gef.idGenero ");
                    query.Append("WHERE gef.idGeneroFaixa = ").Append(generoId);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                generos.Add(new MGenero(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query.ToString() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
                throw;
            }

            return generos;
        }

        public List<MGenero> RetornaGeneroPorArtistaId(int artistaId)
        {
            List<MGenero> gens = new List<MGenero>();

            using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
            {
                connection.Open();
                string query = "SELECT idGenero, descricaoGenero FROM TBGenero WHERE idGenero = " + artistaId;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            gens.Add(new MGenero(reader.GetInt32(0), reader.GetString(1)));
                            return gens;
                        }
                    }
                }
            }

            return gens;
        }
    }
}
