using OrganizadorApolo.Controllers.Imagem;
using OrganizadorApolo.Controllers.Log;
using OrganizadorApolo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace OrganizadorApolo.Controllers.Database
{
    public class ImagemDAO
    {
        private readonly SqlConnection sqlConn;

        public ImagemDAO()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_string_sql"].ConnectionString);
        }

        public bool InsereImagem(string strCaminhoImagem)
        {
            string query = "";
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query = "INSERT INTO TBImagem(caminhoImagem, imagem)" +
                    "select 'Inserido via t-sql', * from openrowset (bulk '" + strCaminhoImagem + "', single_blob) imagem";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query + "\n" +
                                "> StackTrace: " + ex.StackTrace);

            }
            return false;
        }

        public List<MImagem> RetornaImagensPorAlbumId(int idAlbum)
        {
            List<MImagem> imagens = new List<MImagem>();
            TrataImagem tImagem = null;

            using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
            {
                connection.Open();
                string query = "SELECT idImagem, caminhoImagem, imagem FROM TBImagem img INNER JOIN TBAlbum alb ON img.idAlbum = alb.idAlbum WHERE img.idAlbum = " + idAlbum;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MemoryStream ms = new MemoryStream(reader.GetByte(2));
                            byte[] img = ms.ToArray();

                            imagens.Add(new MImagem(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                tImagem.ByteArrayToImage(img)
                            ));
                        }
                    }
                }
            }

            return imagens;
        }

        public MImagem RetornaImagemPorIdImagem(int idImagem)
        {
            MImagem imagem = null;
            TrataImagem tImagem = null;

            using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
            {
                connection.Open();
                string query = "SELECT caminhoImagem, imagem FROM TBImagem WHERE idImagem = " + idImagem;
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            imagem.IdImagem = idImagem;
                            imagem.CaminhoImagem = reader.GetString(1);
                            byte[] vetorImagem = (byte[])command.ExecuteScalar();
                            imagem.Imagem = tImagem.ByteArrayToImage(vetorImagem);
                        }
                        return imagem;
                    }
                }
            }

        }
    }
}
