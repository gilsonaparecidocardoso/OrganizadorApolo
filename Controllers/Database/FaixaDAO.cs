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
    public class FaixaDAO
    {
        private readonly SqlConnection sqlConn;

        public FaixaDAO()
        {
            sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn_string_sql"].ConnectionString);
        }

        public List<MFaixa> RetornaFaixaPorIdAlbum(int _idAlbum)
        {
            StringBuilder query = new StringBuilder();
            try
            {
                List<MFaixa> faixas = new List<MFaixa>();

                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT idFaixa, idAlbum, idGenero, nroFaixa, titulo, duracao, tagVersion, descricao, ");
                    query.Append("tamanho, compositor, legenda, classificacao, artistaParticipante, taxaDeBits, batidasPorMinuto, ");
                    query.Append("frequencia, modo, caminhoArquivo ");
                    query.Append("FROM TBFaixa ");
                    query.Append("WHERE idAlbum = ").Append(_idAlbum);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MFaixa faixa = new MFaixa();
                                faixa.IdFaixa = reader.SafeGetInt(0);
                                faixa.IdAlbum = reader.SafeGetInt(1);
                                faixa.Genero = new List<MGenero>(reader.SafeGetInt(2));
                                faixa.NroFaixa = reader.SafeGetInt(3);
                                faixa.Titulo = reader.SafeGetString(4);
                                faixa.Duracao = reader.SafeGetTimeSpan(5);
                                faixa.TagVersion = reader.SafeGetString(6);
                                faixa.Descricao = reader.SafeGetString(7);
                                faixa.Tamanho = reader.SafeGetString(8);
                                faixa.Compositor = reader.SafeGetString(9);
                                faixa.Legenda = reader.SafeGetString(10);
                                faixa.Classificacao = reader.SafeGetInt(11);
                                faixa.ArtistaParticipante = reader.SafeGetString(12);
                                faixa.TaxaDeBits = reader.SafeGetInt(13);
                                faixa.BatidasPorMinuto = reader.SafeGetInt(14);
                                faixa.Frequencia = reader.SafeGetInt(15);
                                faixa.Modo = reader.SafeGetString(16);
                                faixa.CaminhoArquivo = reader.SafeGetString(17);

                                faixas.Add(faixa);
                            }

                            return faixas;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query.ToString() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return null;
        }

        internal bool IncluirLetra(MFaixa _faixa)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("UPDATE TBFaixa SET letra = '" + _faixa.Letra + "' ");
                    query.Append("WHERE idFaixa = ").Append(_faixa.IdFaixa);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
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

        public List<MFaixa> RetornaFaixaPorArtistaId(int _idArtista)
        {
            StringBuilder query = new StringBuilder();
            List<MFaixa> faixas = new List<MFaixa>();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT fai.idFaixa, fai.idAlbum, fai.idGenero, fai.nroFaixa, fai.titulo, fai.duracao, ");
                    query.Append("fai.tagVersion, fai.descricao, fai.tamanho, fai.compositor, fai.legenda, fai.classificacao, ");
                    query.Append("fai.artistaParticipante, fai.taxaDeBits, fai.batidasPorMinuto, fai.frequencia, fai.modo, ");
                    query.Append("fai.caminhoArquivo, alb.titulo, alb.ano, alb.multiplo, fai.letra ");
                    query.Append("FROM TBFaixa fai");
                    query.Append("INNER JOIN TBAlbum alb ON alb.idArtista = ").Append(_idArtista);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                faixas.Add(new MFaixa(
                                    reader.SafeGetInt(0),
                                    reader.SafeGetInt(1),
                                    new List<MGenero>(reader.SafeGetInt(2)),
                                    reader.SafeGetInt(3),
                                    reader.SafeGetString(4),
                                    reader.SafeGetTimeSpan(5),
                                    reader.SafeGetString(6),
                                    reader.SafeGetString(7),
                                    reader.SafeGetString(8),
                                    reader.SafeGetString(9),
                                    reader.SafeGetString(10),
                                    reader.SafeGetInt(11),
                                    reader.SafeGetString(12),
                                    reader.SafeGetInt(13),
                                    reader.SafeGetInt(14),
                                    reader.SafeGetInt(15),
                                    reader.SafeGetString(16),
                                    reader.SafeGetString(17),
                                    reader.SafeGetString(18)
                                ));

                                return faixas;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return faixas;
        }
        public List<MFaixa> RetornaTodasFaixas()
        {
            StringBuilder query = new StringBuilder();
            List<MFaixa> faixas = new List<MFaixa>();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("SELECT idFaixa, idAlbum, idGenero, nroFaixa, titulo, duracao, tagVersion, descricao, ");
                    query.Append("tamanho, compositor, legenda, classificacao, artistaParticipante, taxaDeBits, batidasPorMinuto, ");
                    query.Append("frequencia, modo, caminhoArquivo, letra ");
                    query.Append("FROM TBFaixa");

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                faixas.Add(new MFaixa(
                                    reader.SafeGetInt(0),
                                    reader.SafeGetInt(1),
                                    new List<MGenero>(reader.SafeGetInt(2)),
                                    reader.SafeGetInt(3),
                                    reader.SafeGetString(4),
                                    reader.SafeGetTimeSpan(5),
                                    reader.SafeGetString(6),
                                    reader.SafeGetString(7),
                                    reader.SafeGetString(8),
                                    reader.SafeGetString(9),
                                    reader.SafeGetString(10),
                                    reader.SafeGetInt(11),
                                    reader.SafeGetString(12),
                                    reader.SafeGetInt(13),
                                    reader.SafeGetInt(14),
                                    reader.SafeGetInt(15),
                                    reader.SafeGetString(16),
                                    reader.SafeGetString(17),
                                    reader.SafeGetString(18)
                                ));
                            }
                        }
                        return faixas;
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Tela: " + this.GetType() + "\n" +
                                "> Query: " + query.ToString() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return faixas;
        }
        public bool Incluir(MFaixa _faixa)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("INSERT INTO TBFaixa(");
                    query.Append("idFaixa, idAlbum, idGenero, nroFaixa, titulo, duracao, tagVersion, descricao, ");
                    query.Append("tamanho, compositor, legenda, classificacao, artistaParticipante, taxaDeBits, batidasPorMinuto, ");
                    query.Append("frequencia, modo, caminhoArquivo, letra) ");
                    query.Append("VALUES(");
                    query.Append(_faixa.IdFaixa + ", ");
                    query.Append(_faixa.IdAlbum + ", ");
                    query.Append(_faixa.Genero[0].IdGenero + ", ");
                    query.Append(_faixa.NroFaixa + ", '");
                    query.Append(_faixa.Titulo + "', ");
                    query.Append(_faixa.Duracao + ", '");
                    query.Append(_faixa.TagVersion + "', '");
                    query.Append(_faixa.Descricao + "', '");
                    query.Append(_faixa.Tamanho + "', '");
                    query.Append(_faixa.Compositor + "', '");
                    query.Append(_faixa.Legenda + "', ");
                    query.Append(_faixa.Classificacao + ", '");
                    query.Append(_faixa.ArtistaParticipante + "', '");
                    query.Append(_faixa.TaxaDeBits + "', ");
                    query.Append(_faixa.BatidasPorMinuto + ", ");
                    query.Append(_faixa.Frequencia + ", '");
                    query.Append(_faixa.Modo + "', '");
                    query.Append(_faixa.CaminhoArquivo + "','");
                    query.Append(_faixa.Letra + "')");

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
            }
            return false;
        }
        public bool Alterar(MFaixa _faixa)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("UPDATE TBFaixa SET(");
                    query.Append("idFaixa, idAlbum, idGenero, nroFaixa, titulo, duracao, tagVersion, descricao, ");
                    query.Append("tamanho, compositor, legenda, classificacao, artistaParticipante, taxaDeBits, batidasPorMinuto, ");
                    query.Append("frequencia, modo, caminhoArquivo, letra) ");
                    query.Append("VALUES(");
                    query.Append(_faixa.IdFaixa + ", ");
                    query.Append(_faixa.IdAlbum + ", ");
                    query.Append(_faixa.Genero[0].IdGenero + ", ");
                    query.Append(_faixa.NroFaixa + ", '");
                    query.Append(_faixa.Titulo + "', ");
                    query.Append(_faixa.Duracao + ", '");
                    query.Append(_faixa.TagVersion + "', '");
                    query.Append(_faixa.Descricao + "', '");
                    query.Append(_faixa.Tamanho + "', '");
                    query.Append(_faixa.Compositor + "', '");
                    query.Append(_faixa.Legenda + "', ");
                    query.Append(_faixa.Classificacao + ", '");
                    query.Append(_faixa.ArtistaParticipante + "', '");
                    query.Append(_faixa.TaxaDeBits + "', ");
                    query.Append(_faixa.BatidasPorMinuto + ", ");
                    query.Append(_faixa.Frequencia + ", '");
                    query.Append(_faixa.Modo + "', '");
                    query.Append(_faixa.CaminhoArquivo + "','");
                    query.Append(_faixa.Letra + "')");
                    query.Append("WHERE idFaixa = ").Append(_faixa.IdFaixa);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
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
        public bool Excluir(int _idFaixa)
        {
            StringBuilder query = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConn.ConnectionString))
                {
                    connection.Open();
                    query.Append("DELETE FROM TBFaixa ");
                    query.Append("WHERE idFaixa = ").Append(_idFaixa);

                    using (SqlCommand command = new SqlCommand(query.ToString(), connection))
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

    }
}
