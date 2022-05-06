using System.Drawing;

namespace OrganizadorApolo.Models
{
    public class MImagem
    {
        public int IdImagem { get; set; }
        public string CaminhoImagem { get; set; }
        public Image Imagem { get; set; }

        public MImagem(int idImagem, string caminhoImagem, Image imagem)
        {
            this.IdImagem = idImagem;
            this.CaminhoImagem = caminhoImagem;
            this.Imagem = imagem;
        }
    }
}
