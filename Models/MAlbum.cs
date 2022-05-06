using OrganizadorApolo.Controllers;
using OrganizadorApolo.Controllers.Database;
using System;
using System.Collections.Generic;

namespace OrganizadorApolo.Models
{
    public class MAlbum
    {
        public int IdAlbum;
        public MArtista Artista;
        public string Titulo;
        public DateTime Ano;
        public int Multiplo;
        public List<MFaixa> Faixas;

        public MAlbum() { }

        public MAlbum(int _idAlbum, MArtista _artista, string _titulo, DateTime _ano, int _multiplo, List<MFaixa> _faixas)
        {
            this.IdAlbum = _idAlbum;
            this.Artista = _artista;
            this.Titulo = _titulo;
            this.Ano = _ano;
            this.Multiplo = _multiplo;
            this.Faixas = _faixas;
        }
        public MAlbum(int _idAlbum)
        {
            CAlbum cAlbum = new CAlbum(new AlbumDAO());
            MAlbum mAlbum = cAlbum.RetornaAlbumPorId(_idAlbum);

            this.IdAlbum = mAlbum.IdAlbum;
            this.Artista = mAlbum.Artista;
            this.Titulo = mAlbum.Titulo;
            this.Ano = mAlbum.Ano;
            this.Multiplo = mAlbum.Multiplo;
            this.Faixas = mAlbum.Faixas;
        }
    }
}
