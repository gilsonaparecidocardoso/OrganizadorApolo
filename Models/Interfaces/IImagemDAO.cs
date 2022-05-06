using OrganizadorApolo.Controllers;
using System.Collections.Generic;
using System.Drawing;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface IImagemDAO
    {
        MImagem RetornaImagemPorIdImagem(int _idImagem);
        List<MImagem> RetornaImagemPorIdAlbum(int _idAlbum);
    }
}
