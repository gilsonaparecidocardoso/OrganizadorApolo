using System.Collections.Generic;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface IFaixaDAO
    {
        bool Incluir(MFaixa _faixa);
        bool Alterar(MFaixa _faixa);
        bool Excluir(int _idFaixa);
        bool IncluirLetra(MFaixa _faixa);
        List<MFaixa> RetornaFaixaPorIdAlbum(int _idAlbum);
        List<MFaixa> RetornaTodasFaixas();
        List<MFaixa> RetornaFaixaPorArtistaId(int _idArtista);

    }
}
