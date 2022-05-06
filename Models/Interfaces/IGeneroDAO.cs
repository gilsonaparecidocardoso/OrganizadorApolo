using System.Collections.Generic;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface IGeneroDAO
    {
        List<MGenero> RetornaGeneroPorId(int _idGeneroFaixa);
        List<MGenero> RetornaTodosGeneros();
        List<MGenero> RetornaGeneroPorArtistaId(int _idArtista);
    }
}
