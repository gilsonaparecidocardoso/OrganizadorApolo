using System.Drawing;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface ITrataImagem
    {
        Image ByteArrayToImage(byte[] _img);
        byte[] ImageToByteArray(Image _img);
    }
}