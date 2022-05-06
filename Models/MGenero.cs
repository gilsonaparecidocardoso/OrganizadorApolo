namespace OrganizadorApolo.Models
{
    public class MGenero
    {
        public int IdGenero { get; set; }
        public string DescricaoGenero { get; set; }

        public MGenero() { }
        public MGenero(int idGenero, string descricaoGenero)
        {
            this.IdGenero = idGenero;
            this.DescricaoGenero = descricaoGenero;
        }
    }
}
