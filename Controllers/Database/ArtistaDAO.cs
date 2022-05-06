using OrganizadorApolo.Controllers.Log;
using OrganizadorApolo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace OrganizadorApolo.Controllers.Database
{
    public class ArtistaDAO
    {
        private readonly SqlConnection sqlConn;

        public ArtistaDAO()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_string_sql"].ConnectionString);
        }

        public MArtista RetornaArtistaPorId(int _idArtista)
        {
            using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
            {
                connection.Open();
                string query = "SELECT Artista FROM TBArtista WHERE idArtista = " + _idArtista;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MArtista(_idArtista, reader.GetString(0));
                        }
                    }
                }
            }

            return null;
        }

        internal MArtista RetornaArtistaPorNome(string _artista)
        {
            MArtista artista = new MArtista();
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT idArtista, artista ");
                    query.Append("FROM TBArtista ");
                    query.Append("WHERE artista = '").Append(_artista).Append("' ");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                artista = new MArtista(reader.GetInt32(0), reader.GetString(1));
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

            return artista;
        }

        public List<MArtista> RetornaTodosArtistas()
        {
            List<MArtista> artistas = new List<MArtista>();

            using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
            {
                connection.Open();
                string query = "SELECT idArtista, artista FROM TBArtista";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            artistas.Add(new MArtista(reader.GetInt32(0), reader.GetString(1)));
                        }
                    }
                }
            }

            return artistas;
        }
        public bool Incluir(MArtista _artista)
        {
            StringBuilder query = new StringBuilder();
            int retorno = -1;
            bool inserido = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("INSERT INTO TBArtista (artista) ");
                    query.Append("VALUES('").Append(_artista.Artista.Trim()).Append("' )");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        retorno = command.ExecuteNonQuery();
                        switch (retorno)
                        {
                            case -1:
                                inserido = false;
                                break;
                            case 0:
                                inserido = false;
                                break;
                            case 1:
                                inserido = true;
                                break;
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

            return inserido;
        }
        public bool Alterar(MArtista artista)
        {
            return false;
        }
        public bool Excluir(int idArtista)
        {
            return false;
        }
    }
}
