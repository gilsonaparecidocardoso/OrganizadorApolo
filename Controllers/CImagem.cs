using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Models;
using OrganizadorApolo.Models.Interfaces;
using System.Collections.Generic;

namespace OrganizadorApolo.Controllers
{
    public class CImagem : IImagemDAO
    {
        private readonly ImagemDAO dao;

        public CImagem(ImagemDAO _dao)
        {
            dao = _dao;
        }

        public List<MImagem> RetornaImagemPorIdAlbum(int albumId)
        {
            return dao.RetornaImagensPorAlbumId(albumId);
        }

        public MImagem RetornaImagemPorIdImagem(int imagemId)
        {
            return dao.RetornaImagemPorIdImagem(imagemId);
        }
    }
}
