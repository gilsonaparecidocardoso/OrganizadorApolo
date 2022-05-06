using System.Collections.Generic;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface IArtistaDAO
    {
        MArtista RetornaArtistaPorId(int _idArtista);
        List<MArtista> RetornaTodosArtistas();
        bool Incluir(MArtista _artista);
        bool Alterar(MArtista _artista);
        bool Excluir(int _idArtista);
    }
}
