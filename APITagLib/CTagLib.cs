using OrganizadorApolo.Controllers;
using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Controllers.Log;
using OrganizadorApolo.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using TagLib;

namespace OrganizadorApolo.APITagLib
{
    public class CTagLib
    {
        public CTagLib()
        {

        }
        public List<MAlbum> RetornaID3(string[] _files)
        {
            List<MFaixa> faixas = new List<MFaixa>();
            CGenero cGenero = new CGenero(new GeneroDAO());
            MAlbum album = new MAlbum();
            List<MAlbum> albuns = new List<MAlbum>();
            CAlbum cAlbum = new CAlbum(new AlbumDAO());
            CArtista cArtista = new CArtista(new ArtistaDAO());
            string novoAlbum = "";

            try
            {
                TagLib.File tagFile = TagLib.File.Create(_files[0]);
                Tag tag = tagFile.GetTag(TagTypes.AllTags);

                for (int i = 0; i < _files.Length; i++)
                {
                    tagFile = TagLib.File.Create(_files[i]);

                    album = cAlbum.RetornaAlbumPorTituloEArtista(tagFile.Tag.Album.Trim(), tagFile.Tag.FirstAlbumArtist.Trim());

                    if (novoAlbum != tagFile.Tag.Album.Trim())
                    {
                        faixas = new List<MFaixa>();
                    }

                    if (novoAlbum != tagFile.Tag.Album.Trim() && tagFile.Tag.Album.Trim() != "")
                    {
                        album = new MAlbum();
                        album.IdAlbum = -1;
                        album.Artista = cArtista.RetornaArtistaPorNome(tagFile.Tag.FirstAlbumArtist.Trim());
                        if (album.Artista.IdArtista <= 0)
                        {
                            if (cArtista.Incluir(new MArtista(tagFile.Tag.FirstAlbumArtist.Trim())))
                            {
                                album.Artista = cArtista.RetornaArtistaPorNome(tagFile.Tag.FirstAlbumArtist.Trim());
                            }
                        }
                        album.Titulo = tagFile.Tag.Album.Trim();
                        album.Ano = new DateTime((int)tagFile.Tag.Year, 1, 1);
                        album.Multiplo = (int)tagFile.Tag.DiscCount;
                        albuns.Add(album);
                    }

                    MFaixa faixa = new MFaixa();
                    faixa.IdFaixa = -1;
                    faixa.IdAlbum = -1;
                    faixa.Genero = cGenero.RetornaGenerosPorDescricao(tagFile.Tag.Genres);
                    faixa.NroFaixa = (int)tagFile.Tag.Track;
                    faixa.Titulo = tagFile.Tag.Title != null ? tagFile.Tag.Title.Trim() : "Faixa Desconhecida";
                    faixa.Duracao = tagFile.Properties.Duration;
                    faixa.TagVersion = "";
                    faixa.Descricao = tagFile.Tag.Description != null ? tagFile.Tag.Description.Trim() : "";
                    faixa.Tamanho = _files.Length.ToString();
                    faixa.Compositor = tagFile.Tag.FirstAlbumArtist != null ? tagFile.Tag.FirstAlbumArtist.Trim() : "";
                    faixa.Legenda = "";
                    faixa.Classificacao = -1;
                    faixa.ArtistaParticipante = tagFile.Tag.JoinedAlbumArtists != null ? tagFile.Tag.JoinedAlbumArtists.Trim() : "";
                    faixa.TaxaDeBits = tagFile.Properties.AudioBitrate;
                    faixa.BatidasPorMinuto = (int)tagFile.Tag.BeatsPerMinute;
                    faixa.Frequencia = -1;
                    faixa.Modo = "";
                    faixa.CaminhoArquivo = _files[i];

                    faixas.Add(faixa);
                    album.Faixas = faixas;

                    novoAlbum = tagFile.Tag.Album;
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Classe: " + this.GetType() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return albuns;
        }

        public static void GetAndSavePictureByTag(Tag tag, string songCoverPath, string songId)
        {
            var ms = new MemoryStream(tag.Pictures[0].Data.Data);
            var image = Image.FromStream(ms);
            var pathSongAlbumCover = songCoverPath + songId + ".jpg";
            image.Save(pathSongAlbumCover);
        }

        public IPicture[] ExtraiImagemID3(TagLib.File _tagFile)
        {
            IPicture[] Imagem = new IPicture[_tagFile.Tag.Pictures.Length];

            if (_tagFile.Tag.Pictures.Length > 0)
            {
                Imagem = _tagFile.Tag.Pictures;
            }

            return Imagem;
        }


        /*
          public static void SetTags (Tag tag)
            {
             tag.Album = "TEST album";
             tag.AlbumArtists = new string [] {"TEST artist 1", "TEST artist 2"};
             tag.BeatsPerMinute = 120;
             tag.Comment = "TEST comment";
             tag.Composers = new string [] {"TEST composer 1", "TEST composer 2"};
             tag.Conductor = "TEST conductor";
             tag.Copyright = "TEST copyright";
             tag.Disc = 100;
             tag.DiscCount = 101;
             tag.Genres = new string [] {"TEST genre 1", "TEST genre 2"};
             tag.Grouping = "TEST grouping";
             tag.Lyrics = "TEST lyrics 1\r\nTEST lyrics 2";
             tag.Performers = new string [] {"TEST performer 1", "TEST performer 2"};
             tag.Title = "TEST title";
             tag.Track = 98;
             tag.TrackCount = 99;
             tag.Year = 1999;
        }
         
         */
    }
}
