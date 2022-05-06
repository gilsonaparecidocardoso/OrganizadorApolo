using OrganizadorApolo.Models.Interfaces;
using System.Drawing;
using System.IO;

namespace OrganizadorApolo.Controllers.Imagem
{
    public class TrataImagem : ITrataImagem
    {
        public Image ByteArrayToImage(byte[] img)
        {
            using (var ms = new MemoryStream(img))
            {
                return Image.FromStream(ms);
            }
        }

        public byte[] ImageToByteArray(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }
    }
}
