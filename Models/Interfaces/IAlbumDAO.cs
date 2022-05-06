using System.Collections.Generic;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface IAlbumDAO
    {
        MAlbum RetornaAlbumPorId(int _idAlbum);
        List<MAlbum> RetornaTodosAlbuns();
        bool Incluir(MAlbum _album);
        bool Alterar(MAlbum _album);
        bool Excluir(int _idAlbum);
    }
}
