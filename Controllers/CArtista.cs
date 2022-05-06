using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Models;
using OrganizadorApolo.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace OrganizadorApolo.Controllers
{
    public class CArtista : IArtistaDAO
    {
        private readonly ArtistaDAO dao;

        public CArtista(ArtistaDAO _dao)
        {
            dao = _dao;
        }

        public bool Alterar(MArtista _artista)
        {
            return dao.Incluir(_artista);
        }

        public bool Excluir(int _idArtista)
        {
            return dao.Excluir(_idArtista);
        }

        public bool Incluir(MArtista _artista)
        {
            return dao.Incluir(_artista);
        }

        public MArtista RetornaArtistaPorId(int _idArtista)
        {
            return dao.RetornaArtistaPorId(_idArtista);
        }
        internal MArtista RetornaArtistaPorNome(string _artista)
        {
            return dao.RetornaArtistaPorNome(_artista);
        }

        public List<MArtista> RetornaTodosArtistas()
        {
            return dao.RetornaTodosArtistas();
        }
    }
}
