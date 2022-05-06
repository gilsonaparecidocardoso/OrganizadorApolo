using OrganizadorApolo.Controllers.Log;
using OrganizadorApolo.Functions;
using OrganizadorApolo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace OrganizadorApolo.Controllers.Database
{
    public class AlbumDAO
    {
        private readonly SqlConnection sqlConn;

        public AlbumDAO()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_string_sql"].ConnectionString);
        }

        public MAlbum RetornaAlbumPorId(int idAlbum)
        {
            StringBuilder query = new StringBuilder();
            MAlbum mAlbum = new MAlbum();
            CGenero cGenero = new CGenero(new GeneroDAO());
            CArtista cArtista = new CArtista(new ArtistaDAO());
            List<MFaixa> faixas = new List<MFaixa>();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT alb.idAlbum, alb.idArtista, alb.titulo, alb.ano, alb.multiplo, ");
                    query.Append("fai.idAlbum, fai.idFaixa, fai.idGeneroFaixa, fai.nroFaixa, fai.titulo, fai.duracao, fai.tagVersion, ");
                    query.Append("fai.descricao, fai.tamanho, fai.compositor, fai.legenda, fai.classificacao, fai.artistaParticipante, ");
                    query.Append("fai.taxaDeBits, fai.batidasPorMinuto, fai.frequencia, fai.modo, fai.caminhoArquivo, fai.letra, ");
                    query.Append("art.idArtista, art.artista ");
                    query.Append("FROM TBAlbum alb ");
                    query.Append("LEFT JOIN TBFaixa fai ON fai.idAlbum = alb.idAlbum ");
                    query.Append("LEFT JOIN TBArtista art ON art.idArtista = alb.idArtista ");
                    query.Append("WHERE alb.idAlbum = ").Append(idAlbum).Append(" ");
                    query.Append("ORDER BY fai.nroFaixa");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MFaixa faixa = new MFaixa();
                                faixa.IdAlbum = reader.SafeGetInt(5);
                                faixa.IdFaixa = reader.SafeGetInt(6);
                                faixa.Genero = cGenero.RetornaGeneroPorId(reader.SafeGetInt(7));
                                faixa.NroFaixa = reader.SafeGetInt(8);
                                faixa.Titulo = reader.SafeGetString(9);
                                faixa.Duracao = reader.SafeGetTimeSpan(10);
                                faixa.TagVersion = reader.SafeGetString(11);
                                faixa.Descricao = reader.SafeGetString(12);
                                faixa.Tamanho = reader.SafeGetString(13);
                                faixa.Compositor = reader.SafeGetString(14);
                                faixa.Legenda = reader.SafeGetString(15);
                                faixa.Classificacao = reader.SafeGetInt(16);
                                faixa.ArtistaParticipante = reader.SafeGetString(17);
                                faixa.TaxaDeBits = reader.SafeGetInt(18);
                                faixa.BatidasPorMinuto = reader.SafeGetInt(19);
                                faixa.Frequencia = reader.SafeGetInt(20);
                                faixa.Modo = reader.SafeGetString(21);
                                faixa.CaminhoArquivo = reader.SafeGetString(22);
                                faixa.Letra = reader.SafeGetString(23);

                                faixas.Add(faixa);

                                if (mAlbum.IdAlbum == 0)
                                {
                                    mAlbum = new MAlbum(
                                        reader.SafeGetInt(0),
                                        cArtista.RetornaArtistaPorId(reader.SafeGetInt(1)),
                                        reader.SafeGetString(2),
                                        reader.SafeGetDateTime(3),
                                        reader.SafeGetInt(4),
                                        faixas);
                                }
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

            return mAlbum;
        }

        internal MAlbum RetornaAlbumPorTituloEArtista(string _titulo, string _artista)
        {
            StringBuilder query = new StringBuilder();
            MAlbum mAlbum = new MAlbum();
            CGenero cGenero = new CGenero(new GeneroDAO());
            CArtista cArtista = new CArtista(new ArtistaDAO());
            List<MFaixa> faixas = new List<MFaixa>();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT alb.idAlbum, alb.idArtista, alb.titulo, alb.ano, alb.multiplo, ");
                    query.Append("fai.idAlbum, fai.idFaixa, fai.idGeneroFaixa, fai.nroFaixa, fai.titulo, fai.duracao, fai.tagVersion, ");
                    query.Append("fai.descricao, fai.tamanho, fai.compositor, fai.legenda, fai.classificacao, fai.artistaParticipante, ");
                    query.Append("fai.taxaDeBits, fai.batidasPorMinuto, fai.frequencia, fai.modo, fai.caminhoArquivo, fai.letra, ");
                    query.Append("art.idArtista, art.artista ");
                    query.Append("FROM TBAlbum alb ");
                    query.Append("INNER JOIN TBFaixa fai ON fai.idAlbum = alb.idAlbum ");
                    query.Append("INNER JOIN TBArtista art ON art.idArtista = alb.idArtista ");
                    query.Append("WHERE alb.titulo = '").Append(_titulo).Append("' ");
                    query.Append("AND art.artista = '").Append(_artista).Append("' ");
                    query.Append("ORDER BY fai.nroFaixa");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MFaixa faixa = new MFaixa();
                                faixa.IdAlbum = reader.SafeGetInt(5);
                                faixa.IdFaixa = reader.SafeGetInt(6);
                                faixa.Genero = cGenero.RetornaGeneroPorId(reader.SafeGetInt(7));
                                faixa.NroFaixa = reader.SafeGetInt(8);
                                faixa.Titulo = reader.SafeGetString(9);
                                faixa.Duracao = reader.SafeGetTimeSpan(10);
                                faixa.TagVersion = reader.SafeGetString(11);
                                faixa.Descricao = reader.SafeGetString(12);
                                faixa.Tamanho = reader.SafeGetString(13);
                                faixa.Compositor = reader.SafeGetString(14);
                                faixa.Legenda = reader.SafeGetString(15);
                                faixa.Classificacao = reader.SafeGetInt(16);
                                faixa.ArtistaParticipante = reader.SafeGetString(17);
                                faixa.TaxaDeBits = reader.SafeGetInt(18);
                                faixa.BatidasPorMinuto = reader.SafeGetInt(19);
                                faixa.Frequencia = reader.SafeGetInt(20);
                                faixa.Modo = reader.SafeGetString(21);
                                faixa.CaminhoArquivo = reader.SafeGetString(22);
                                faixa.Letra = reader.SafeGetString(23);

                                faixas.Add(faixa);

                                if (mAlbum.IdAlbum == 0)
                                {
                                    mAlbum = new MAlbum(
                                        reader.SafeGetInt(0),
                                        cArtista.RetornaArtistaPorId(reader.SafeGetInt(1)),
                                        reader.SafeGetString(2),
                                        reader.SafeGetDateTime(3),
                                        reader.SafeGetInt(4),
                                        faixas);
                                }
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

            return mAlbum;
        }

        public List<MAlbum> RetornaTodosAlbuns()
        {
            StringBuilder query = new StringBuilder();
            MAlbum album = new MAlbum();
            CGenero cGenero = new CGenero(new GeneroDAO());
            CArtista cArtista = new CArtista(new ArtistaDAO());
            List<MAlbum> albuns = new List<MAlbum>();
            List<MFaixa> faixas = new List<MFaixa>();
            string novoAlbum = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT alb.idAlbum, alb.idArtista, alb.titulo, alb.ano, alb.multiplo, ");
                    query.Append("fai.idAlbum, fai.idFaixa, fai.idGeneroFaixa, fai.nroFaixa, fai.titulo, fai.duracao, fai.tagVersion, ");
                    query.Append("fai.descricao, fai.tamanho, fai.compositor, fai.legenda, fai.classificacao, fai.artistaParticipante, ");
                    query.Append("fai.taxaDeBits, fai.batidasPorMinuto, fai.frequencia, fai.modo, fai.caminhoArquivo, fai.letra, ");
                    query.Append("art.idArtista, art.artista ");
                    query.Append("FROM TBAlbum alb ");
                    query.Append("LEFT JOIN TBFaixa fai ON fai.idAlbum = alb.idAlbum ");
                    query.Append("INNER JOIN TBArtista art ON art.idArtista = alb.idArtista ");
                    query.Append("ORDER BY alb.titulo, fai.nroFaixa");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (novoAlbum != reader.SafeGetString(2))
                                {
                                    faixas = new List<MFaixa>();
                                }

                                if (novoAlbum != reader.SafeGetString(2) && reader.SafeGetString(2) != "")
                                {
                                    album = new MAlbum();
                                    album.IdAlbum = reader.SafeGetInt(5);
                                    album.Artista = cArtista.RetornaArtistaPorId(reader.SafeGetInt(1));
                                    album.Titulo = reader.SafeGetString(2);
                                    album.Ano = DateTime.MinValue;
                                    album.Multiplo = 1;
                                    albuns.Add(album);
                                }

                                MFaixa faixa = new MFaixa();
                                faixa.IdAlbum = reader.SafeGetInt(5);
                                faixa.IdFaixa = reader.SafeGetInt(6);
                                faixa.Genero = cGenero.RetornaGeneroPorId(reader.SafeGetInt(7));
                                faixa.NroFaixa = reader.SafeGetInt(8);
                                faixa.Titulo = reader.SafeGetString(9);
                                faixa.Duracao = reader.SafeGetTimeSpan(10);
                                faixa.TagVersion = reader.SafeGetString(11);
                                faixa.Descricao = reader.SafeGetString(12);
                                faixa.Tamanho = reader.SafeGetString(13);
                                faixa.Compositor = reader.SafeGetString(14);
                                faixa.Legenda = reader.SafeGetString(15);
                                faixa.Classificacao = reader.SafeGetInt(16);
                                faixa.ArtistaParticipante = reader.SafeGetString(17);
                                faixa.TaxaDeBits = reader.SafeGetInt(18);
                                faixa.BatidasPorMinuto = reader.SafeGetInt(19);
                                faixa.Frequencia = reader.SafeGetInt(20);
                                faixa.Modo = reader.SafeGetString(21);
                                faixa.CaminhoArquivo = reader.SafeGetString(22);
                                faixa.Letra = reader.SafeGetString(23);

                                faixas.Add(faixa);

                                album.Faixas = faixas;

                                novoAlbum = reader.SafeGetString(2);

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

            return albuns;
        }
        public bool Incluir(MAlbum _album)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("INSERT INTO TBAlbum(idArtista, titulo, ano, multiplo)");
                    query.Append("VALUES(").Append(_album.Artista.IdArtista).Append(", '");
                    query.Append(_album.Titulo + "', '");
                    query.Append(_album.Ano + "', ");
                    query.Append(_album.Multiplo + ")");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        return command.ExecuteNonQuery() > 0;
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
            //return false;
        }
        public bool Alterar(MAlbum _album)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("UPDATE TBAlbum ");
                    query.Append("SET idArtista = ").Append(_album.Artista.IdArtista);
                    query.Append(", titulo = '").Append(_album.Titulo);
                    query.Append("', ano = '").Append(_album.Ano);
                    query.Append("', multiplo = ").Append(_album.Multiplo);
                    query.Append(" WHERE idAlbum = ").Append(_album.IdAlbum);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        return command.ExecuteNonQuery() > 0;
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
            //return false;
        }
        public bool Excluir(int _idAlbum)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("DELETE FROM TBAlbum ");
                    query.Append("WHERE idAlbum = ").Append(_idAlbum);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        return command.ExecuteNonQuery() > 0;
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
            //return false;
        }
    }
}
