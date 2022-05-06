using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Models;
using OrganizadorApolo.Models.Interfaces;
using System.Collections.Generic;

namespace OrganizadorApolo.Controllers
{
    public class CGenero : IGeneroDAO
    {
        private readonly GeneroDAO dao;

        public CGenero(GeneroDAO _dao)
        {
            dao = _dao;
        }

        public List<MGenero> RetornaGeneroPorArtistaId(int artistaId)
        {
            return dao.RetornaGeneroPorArtistaId(artistaId);
        }

        public List<MGenero> RetornaGeneroPorId(int generoId)
        {
            return dao.RetornaGenerosPorId(generoId);
        }

        public List<MGenero> RetornaTodosGeneros()
        {
            return dao.RetornaTodosGeneros();
        }

        internal List<MGenero> RetornaGenerosPorDescricao(string[] _genero)
        {
            return dao.RetornaIdPorGenero(_genero);
        }
    }
}
