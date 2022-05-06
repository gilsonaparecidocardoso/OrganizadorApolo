using System;
using System.Collections.Generic;

namespace OrganizadorApolo.Models
{
    public class MFaixa
    {             
        public int IdFaixa;
        public int IdAlbum;
        public List<MGenero> Genero;
        public int NroFaixa;
        public string Titulo;
        public TimeSpan Duracao;
        public string TagVersion;
        public string Descricao;
        public string Tamanho;
        public string Compositor;
        public string Legenda;
        public int Classificacao;
        public string ArtistaParticipante;
        public int TaxaDeBits;
        public int BatidasPorMinuto;
        public int Frequencia;
        public string Modo;
        public string CaminhoArquivo;
        public string Letra;

        public MFaixa() { }

        public MFaixa(int idFaixa, int idAlbum, List<MGenero> genero, int nroFaixa, string titulo, TimeSpan duracao,
                      string tagVersion, string descricao, string tamanho, string compositor, string legenda,
                      int classificacao, string artistaParticipante, int taxaDeBits, int batidasPorMinuto, 
                      int frequencia, string modo, string caminhoArquivo, string letra)
        {
            this.IdFaixa = idFaixa;
            this.IdAlbum = idAlbum;
            this.Genero = genero;
            this.NroFaixa = nroFaixa;
            this.Titulo = titulo;
            this.Duracao = duracao;
            this.TagVersion = tagVersion;
            this.Descricao = descricao;
            this.Tamanho = tamanho;
            this.Compositor = compositor;
            this.Legenda = legenda;
            this.Classificacao = classificacao;
            this.ArtistaParticipante = artistaParticipante;
            this.TaxaDeBits = taxaDeBits;
            this.BatidasPorMinuto = batidasPorMinuto;
            this.Frequencia = frequencia;
            this.Modo = modo;
            this.CaminhoArquivo = caminhoArquivo;
            this.Letra = letra;
        }
    }
}
