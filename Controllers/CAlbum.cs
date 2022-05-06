using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Controllers.Diretorio;
using OrganizadorApolo.Models;
using OrganizadorApolo.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace OrganizadorApolo.Controllers
{
    public class CAlbum : IAlbumDAO
    {
        private readonly AlbumDAO dao;
        private readonly TrataDiretorio cTrataDiretorio;

        public CAlbum(AlbumDAO _dao)
        {
            dao = _dao;
            cTrataDiretorio = new TrataDiretorio();
        }

        public bool Alterar(MAlbum _album)
        {
            return dao.Alterar(_album);
        }

        public bool Excluir(int _idAlbum)
        {
            return dao.Excluir(_idAlbum);
        }

        public bool Incluir(MAlbum _album)
        {
            return dao.Incluir(_album);
        }

        public MAlbum RetornaAlbumPorId(int _idAlbum)
        {
            return dao.RetornaAlbumPorId(_idAlbum);
        }

        public List<MAlbum> RetornaTodosAlbuns()
        {
            return dao.RetornaTodosAlbuns();
        }

        internal MAlbum RetornaAlbumPorTituloEArtista(string _titulo, string _artista)
        {
            return dao.RetornaAlbumPorTituloEArtista(_titulo, _artista);
        }

        internal List<MAlbum> RetornaAlbunsDoDiretorio(string _diretorio)
        {
            return cTrataDiretorio.RetornaAlbunsDoDiretorio(_diretorio);
        }
    }
}
