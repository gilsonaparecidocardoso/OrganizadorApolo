using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Models;
using OrganizadorApolo.Models.Interfaces;
using System.Collections.Generic;

namespace OrganizadorApolo.Controllers
{
    public class CFaixa : IFaixaDAO
    {
        private readonly FaixaDAO dao;

        public CFaixa(FaixaDAO _dao)
        {
            dao = _dao;
        }
        public bool Alterar(MFaixa _faixa)
        {
            return dao.Alterar(_faixa);
        }

        public bool Excluir(int _idFaixa)
        {
            return dao.Excluir(_idFaixa);
        }

        public bool Incluir(MFaixa _faixa)
        {
            return dao.Incluir(_faixa);
        }

        public bool IncluirLetra(MFaixa _faixa)
        {
            return dao.IncluirLetra(_faixa);
        }

        public List<MFaixa> RetornaFaixaPorIdAlbum(int _idAlbum)
        {
            return dao.RetornaFaixaPorIdAlbum(_idAlbum);
        }

        public List<MFaixa> RetornaFaixaPorArtistaId(int _idArtista)
        {
            return dao.RetornaFaixaPorArtistaId(_idArtista);
        }

        public List<MFaixa> RetornaTodasFaixas()
        {
            return dao.RetornaTodasFaixas();
        }

    }
}
