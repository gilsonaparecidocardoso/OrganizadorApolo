namespace OrganizadorApolo.Models
{
    public class MArtista
    {
        public int IdArtista { get; set; }
        public string Artista { get; set; }

        public MArtista() { }
        public MArtista(string _artista)
        {
            this.Artista = _artista;
        }
        public MArtista(int _idArtista, string _artista)
        {
            this.IdArtista = _idArtista;
            this.Artista = _artista;
        }
    }
}
