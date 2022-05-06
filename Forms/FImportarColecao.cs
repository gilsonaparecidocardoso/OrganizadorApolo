using OrganizadorApolo.Controllers;
using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Controllers.Diretorio;
using OrganizadorApolo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using OrganizadorApolo.APITagLib;

namespace OrganizadorApolo.Forms
{
    public partial class FImportarColecao : Form
    {
        DataTable dtImportar = new DataTable();
        //private CFaixa cFaixa;
        //private List<MFaixa> faixas;
        private List<MFaixa> faixasImportar;
        //private TrataDiretorio trataDiretorio;
        private CAlbum cAlbum;
        private List<MAlbum> albuns;
        private List<MAlbum> todosAlbuns;

        public FImportarColecao()
        {
            InitializeComponent();

            cAlbum = new CAlbum(new AlbumDAO());
            faixasImportar = new List<MFaixa>();

            todosAlbuns = cAlbum.RetornaTodosAlbuns(); //VEM DO BD
            albuns = cAlbum.RetornaAlbunsDoDiretorio(textBox1.Text); //VEM DO DIRETORIO + ID3
            albuns = ConsolidaBDComDiretorio(todosAlbuns, albuns);
        }

        /// <summary>
        /// Consolida as informações das duas fontes
        /// </summary>
        /// <param name="_albunsBD">Vem do BD</param>
        /// <param name="_albunsDiretorio">Vem do Diretório</param>
        /// <returns></returns>
        private List<MAlbum> ConsolidaBDComDiretorio(List<MAlbum> _albunsBD, List<MAlbum> _albunsDiretorio)
        {
            List<MAlbum> albuns = new List<MAlbum>();
            CArtista cArtista = new CArtista(new ArtistaDAO());

            foreach (var albumDir in _albunsDiretorio)
            {
                MAlbum album = new MAlbum();

                //Procura no BD se tem o album do diretorio
                var filtrado = _albunsBD.Where(x => x.Titulo.Contains(albumDir.Titulo)).ToList();

                foreach (var albumBD in filtrado)
                {
                    if (albumBD.IdAlbum > 0 && albumDir.IdAlbum <= 0)
                    {
                        album.IdAlbum = albumBD.IdAlbum;
                    }
                    else if (albumDir.IdAlbum > 0)
                    {
                        album.IdAlbum = albumDir.IdAlbum;
                    }
                    else
                    {
                        album.IdAlbum = -1;  //Não encontrado - será incluído
                    }

                    if (albumBD.Artista.IdArtista > 0 && albumDir.Artista.IdArtista <= 0)
                    {
                        album.Artista.IdArtista = albumBD.Artista.IdArtista;
                    }
                    else if (albumDir.Artista.IdArtista > 0)
                    {
                        album.Artista = albumDir.Artista;
                    }
                    else
                    {
                        album.Artista = albumBD.Artista;
                    }

                    if (albumBD.Ano > DateTime.MinValue && albumDir.Ano == DateTime.MinValue)
                    {
                        album.Ano = albumBD.Ano;
                    }
                    else if (albumDir.Ano > DateTime.MinValue)
                    {
                        album.Ano = albumDir.Ano;
                    }
                    else
                    {
                        album.Ano = DateTime.MinValue;
                    }

                    if (albumBD.Multiplo > 0 && albumDir.Multiplo <= 0)
                    {
                        album.Multiplo = albumBD.Multiplo;
                    }
                    else if (albumDir.Multiplo > 0)
                    {
                        album.Multiplo = albumDir.Multiplo;
                    }
                    else
                    {
                        album.Multiplo = albumDir.Multiplo;//ID3?
                    }

                    if (albumBD.Faixas.Count > 0 && albumDir.Faixas.Count == 0)
                    {
                        album.Faixas = albumBD.Faixas;
                    }
                    else if (albumDir.Faixas.Count > 0 && albumBD.Faixas.Count == 0) //Faixa nova
                    {
                        foreach (var faixaDir in albumDir.Faixas)
                        {
                            MFaixa faixa = new MFaixa();
                            faixa.IdFaixa = faixaDir.IdFaixa;
                            faixa.IdAlbum = faixaDir.IdAlbum;
                            faixa.Genero = faixaDir.Genero;
                            faixa.NroFaixa = faixaDir.NroFaixa;
                            faixa.Titulo = faixaDir.Titulo;
                            faixa.Duracao = faixaDir.Duracao;
                            faixa.TagVersion = faixaDir.TagVersion;
                            faixa.Descricao = faixaDir.Descricao;
                            faixa.Tamanho = faixaDir.Tamanho;
                            faixa.Compositor = faixaDir.Compositor;
                            faixa.Legenda = faixaDir.Legenda;
                            faixa.Classificacao = faixaDir.Classificacao;
                            faixa.ArtistaParticipante = faixaDir.ArtistaParticipante;
                            faixa.TaxaDeBits = faixaDir.TaxaDeBits;
                            faixa.BatidasPorMinuto = faixaDir.BatidasPorMinuto;
                            faixa.Frequencia = faixaDir.Frequencia;
                            faixa.Modo = faixaDir.Modo;
                            faixa.CaminhoArquivo = faixaDir.CaminhoArquivo;

                            album.Faixas.Add(faixa);
                        }
                    }
                    else //Faixa ja existe
                    {
                        if (albumDir.Faixas.Count > 0)
                        {
                            MFaixa faixa;

                            foreach (var faixaDir in albumDir.Faixas) //15 faixas
                            {
                                //BUG
                                //Cenario 1:
                                //No BD tem 1 faixa do Album.
                                //No diretorio tem 15.
                                //Percorrer faixas do diretorio sobre o BD.

                                //Cenario 2:
                                //No diretorio tem 1 faixa do Album.
                                //No BD tem 15.
                                //Percorrer faixas do BD sobre o diretorio.
                                
                                ////Procura no BD se tem a faixa do diretorio
                                //var filtrado2 = _albunsBD.Where(x => x.Faixas.Contains(faixaDir.Titulo)).ToList();

                                //foreach (var faixaBD in filtrado2)
                                ////    foreach (var faixaBD in albumBD.Faixas)
                                //{
                                //}


                                foreach (var faixaBD in albumBD.Faixas) //1 faixa
                                {
                                    faixa = new MFaixa();

                                    if (faixaDir.ArtistaParticipante.Length > 0 && faixaBD.ArtistaParticipante.Length == 0)
                                    {
                                        faixa.ArtistaParticipante = faixaDir.ArtistaParticipante;
                                    }
                                    else if (faixaBD.ArtistaParticipante.Length > 0 && faixaDir.ArtistaParticipante.Length == 0)
                                    {
                                        faixa.ArtistaParticipante = faixaBD.ArtistaParticipante;
                                    }
                                    else
                                    {
                                        faixa.ArtistaParticipante = "";
                                    }

                                    if (faixaDir.BatidasPorMinuto > 0 && faixaBD.BatidasPorMinuto == 0)
                                    {
                                        faixa.BatidasPorMinuto = faixaDir.BatidasPorMinuto;
                                    }
                                    else if (faixaBD.BatidasPorMinuto > 0 && faixaDir.BatidasPorMinuto > 0)
                                    {
                                        faixa.BatidasPorMinuto = faixaBD.BatidasPorMinuto;
                                    }
                                    else
                                    {
                                        faixa.BatidasPorMinuto = 0;
                                    }

                                    if (faixaDir.CaminhoArquivo.Length > 0 && faixaBD.CaminhoArquivo.Length == 0)
                                    {
                                        faixa.CaminhoArquivo = faixaDir.CaminhoArquivo;
                                    }
                                    else if (faixaBD.CaminhoArquivo.Length > 0 && faixaDir.CaminhoArquivo.Length == 0)
                                    {
                                        faixa.CaminhoArquivo = faixaBD.CaminhoArquivo;
                                    }
                                    else
                                    {
                                        faixa.CaminhoArquivo = "";
                                    }

                                    if (faixaDir.Classificacao > 0 && faixaBD.Classificacao == 0)
                                    {
                                        faixa.Classificacao = faixaDir.Classificacao;
                                    }
                                    else if (faixaBD.Classificacao > 0 && faixaDir.Classificacao == 0)
                                    {
                                        faixa.Classificacao = faixaBD.Classificacao;
                                    }
                                    else
                                    {
                                        faixa.Classificacao = 0;
                                    }

                                    if (faixaDir.Compositor.Length > 0 && faixaBD.Compositor.Length == 0)
                                    {
                                        faixa.Compositor = faixaDir.Compositor;
                                    }
                                    else if (faixaBD.Compositor.Length > 0 && faixaDir.Compositor.Length == 0)
                                    {
                                        faixa.Compositor = faixaBD.Compositor;
                                    }
                                    else
                                    {
                                        faixa.Compositor = "";
                                    }

                                    if (faixaDir.Descricao.Length > 0 && faixaBD.Descricao.Length == 0)
                                    {
                                        faixa.Descricao = faixaDir.Descricao;
                                    }
                                    else if (faixaBD.Descricao.Length > 0 && faixaDir.Descricao.Length == 0)
                                    {
                                        faixa.Descricao = faixaBD.Descricao;
                                    }
                                    else
                                    {
                                        faixa.Descricao = "";
                                    }

                                    if (faixaDir.Duracao.CompareTo(TimeSpan.MinValue) == 1 && faixaBD.Duracao.CompareTo(TimeSpan.MinValue) == 0)
                                    {
                                        faixa.Duracao = faixaDir.Duracao;
                                    }
                                    else if (faixaBD.Duracao.CompareTo(TimeSpan.MinValue) == 1 && faixaDir.Duracao.CompareTo(TimeSpan.MinValue) == 0)
                                    {
                                        faixa.Duracao = faixaBD.Duracao;
                                    }
                                    else
                                    {
                                        faixa.Duracao = new TimeSpan(0, 0, 0);
                                    }

                                    if (faixaDir.Frequencia > 0 && faixaBD.Frequencia == 0)
                                    {
                                        faixa.Frequencia = faixaDir.Frequencia;
                                    }
                                    else if (faixaBD.Frequencia > 0 && faixaDir.Frequencia == 0)
                                    {
                                        faixa.Frequencia = faixaBD.Frequencia;
                                    }
                                    else
                                    {
                                        faixa.Frequencia = 0;
                                    }

                                    if (faixaDir.Genero.Count > 0 && faixaBD.Genero.Count == 0)
                                    {
                                        faixa.Genero = faixaDir.Genero;
                                    }
                                    else if (faixaBD.Genero.Count > 0 && faixaDir.Genero.Count == 0)
                                    {
                                        faixa.Genero = faixaBD.Genero;
                                    }
                                    else
                                    {
                                        faixa.Genero = new List<MGenero>();
                                    }

                                    if (faixaDir.IdAlbum > 0 && faixaBD.IdAlbum == 0)
                                    {
                                        faixa.IdAlbum = faixaDir.IdAlbum;
                                    }
                                    else if (faixaBD.IdAlbum > 0 && faixaDir.IdAlbum == 0)
                                    {
                                        faixa.IdAlbum = faixaBD.IdAlbum;
                                    }
                                    else
                                    {
                                        faixa.IdAlbum = -1;
                                    }

                                    if (faixaDir.IdFaixa > 0 && faixaBD.IdFaixa == 0)
                                    {
                                        faixa.IdFaixa = faixaDir.IdFaixa;
                                    }
                                    else if (faixaBD.IdFaixa > 0 && faixaDir.IdFaixa == 0)
                                    {
                                        faixa.IdFaixa = faixaBD.IdFaixa;
                                    }
                                    else
                                    {
                                        faixa.IdFaixa = -1;
                                    }

                                    if (faixaDir.Legenda.Length > 0 && faixaBD.Legenda.Length == 0)
                                    {
                                        faixa.Legenda = faixaDir.Legenda;
                                    }
                                    else if (faixaBD.Legenda.Length > 0 && faixaDir.Legenda.Length == 0)
                                    {
                                        faixa.Legenda = faixaBD.Legenda;
                                    }
                                    else
                                    {
                                        faixa.Legenda = "";
                                    }
                                    if (faixaDir.Letra != null)
                                    {
                                        if (faixaDir.Letra.Length > 0 && faixaBD.Letra.Length == 0)
                                        {
                                            faixa.Letra = faixaDir.Letra;
                                        }
                                        else if (faixaBD.Letra.Length > 0 && faixaDir.Letra.Length == 0)
                                        {
                                            faixa.Letra = faixaBD.Letra;
                                        }
                                        else
                                        {
                                            faixa.Letra = "";
                                        }
                                    }
                                    else
                                    {
                                        faixa.Letra = "";
                                    }

                                    if (faixaDir.Modo.Length > 0 && faixaBD.Modo.Length == 0)
                                    {
                                        faixa.Modo = faixaDir.Modo;
                                    }
                                    else if (faixaBD.Modo.Length > 0 && faixaDir.Modo.Length == 0)
                                    {
                                        faixa.Modo = faixaBD.Modo;
                                    }
                                    else
                                    {
                                        faixa.Modo = "";
                                    }

                                    if (faixaDir.NroFaixa > 0 && faixaBD.NroFaixa == 0)
                                    {
                                        faixa.NroFaixa = faixaDir.NroFaixa;
                                    }
                                    else if (faixaBD.NroFaixa > 0 && faixaDir.NroFaixa == 0)
                                    {
                                        faixa.NroFaixa = faixaBD.NroFaixa;
                                    }
                                    else
                                    {
                                        faixa.NroFaixa = 0;
                                        //string nro = faixaBD.Titulo.Substring(0, 2);
                                    }

                                    if (faixaDir.TagVersion.Length > 0 && faixaBD.TagVersion.Length == 0)
                                    {
                                        faixa.TagVersion = faixaDir.TagVersion;
                                    }
                                    else if (faixaBD.TagVersion.Length > 0 && faixaDir.TagVersion.Length == 0)
                                    {
                                        faixa.TagVersion = faixaBD.TagVersion;
                                    }
                                    else
                                    {
                                        faixa.TagVersion = "";
                                    }

                                    if (faixaDir.Tamanho.Length > 0 && faixaBD.Tamanho.Length == 0)
                                    {
                                        faixa.Tamanho = faixaDir.Tamanho;
                                    }
                                    else if (faixaBD.Tamanho.Length > 0 && faixaDir.Tamanho.Length == 0)
                                    {
                                        faixa.Tamanho = faixaBD.Tamanho;
                                    }
                                    else
                                    {
                                        faixa.Tamanho = "";
                                    }

                                    if (faixaDir.TaxaDeBits > 0 && faixaBD.TaxaDeBits == 0)
                                    {
                                        faixa.TaxaDeBits = faixaDir.TaxaDeBits;
                                    }
                                    else if (faixaBD.TaxaDeBits > 0 && faixaDir.TaxaDeBits == 0)
                                    {
                                        faixa.TaxaDeBits = faixaBD.TaxaDeBits;
                                    }
                                    else
                                    {
                                        faixa.TaxaDeBits = 0;
                                    }


                                    if (faixaDir.Titulo.Length > 0)
                                    {
                                        faixa.Titulo = faixaDir.Titulo;
                                    }
                                    else if (faixaBD.Titulo.Length > 0)
                                    {
                                        faixa.Titulo = faixaBD.Titulo;
                                    }
                                    else
                                    {
                                        faixa.Titulo = "";
                                    }

                                    faixasImportar.Add(faixa);                                    
                                }
                            }
                        }
                        else
                        {
                            if (albumBD.Faixas.Count > 0)
                            {
                                //album = albumBD;
                            }
                        }
                    }
                }

                if (filtrado.Count == 0)
                {
                    //Não encontrado - será incluído
                    album.IdAlbum = -1;
                    album.Artista = albumDir.Artista;
                    album.Titulo = albumDir.Titulo;
                    album.Ano = albumDir.Ano;
                    album.Multiplo = albumDir.Multiplo;
                    album.Faixas = albumDir.Faixas;
                }
                else
                {
                    album.Faixas = faixasImportar;
                }
                
                albuns.Add(album);

            }

            return albuns;
        }

        private void FImportarColecao_Load(object sender, EventArgs e)
        {
            FormataGrdImportar();
        }

        private void FImportarColecao_FormClosed(object sender, FormClosedEventArgs e)
        {
            MDIPrincipal.fImportarColecao = null;
        }

        private void BtnListar_Click(object sender, EventArgs e)
        {
            CarregaGrdImportar();
        }

        private void BtnMarcar_Click(object sender, EventArgs e)
        {
            int selecionados = 0;

            foreach (DataGridViewRow dr in dtgImportar.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    if (!(bool)dr.Cells[0].Value)
                    {
                        dr.Cells[0].Value = true;
                        selecionados++;
                    }
                }
            }

            toolStripStatusLabel1.Text = selecionados + " de " + dtgImportar.Rows.Count + " selecionado(s).";
        }

        private void BtnDesmarcar_Click(object sender, EventArgs e)
        {
            int selecionados = 0;

            foreach (DataGridViewRow dr in dtgImportar.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    if ((bool)dr.Cells[0].Value)
                    {
                        dr.Cells[0].Value = false;
                        selecionados++;
                    }
                }
            }

            toolStripStatusLabel1.Text = selecionados + " de " + dtgImportar.Rows.Count + " deselecionado(s).";
        }

        private void BtnQuais_Click(object sender, EventArgs e)
        {
            int selecionados = 0;
            foreach (DataGridViewRow dr in dtgImportar.Rows)
            {
                if (dr.Cells[0].Value != null)
                {
                    if ((bool)dr.Cells[0].Value)
                    {
                        selecionados++;
                    }
                }
            }

            toolStripStatusLabel1.Text = selecionados + " de " + dtgImportar.Rows.Count + " selecionado(s).";
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
        }

        private void dtgImportar_Click(object sender, EventArgs e)
        {
        }
        private void dtgImportar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblInfo.Text = "Album: " + dtgImportar.Rows[e.RowIndex].Cells[1].Value.ToString() + "\n" +
                "Faixa: " + dtgImportar.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
        private void FormataGrdImportar()
        {
            dtgImportar.DefaultCellStyle.Font = new Font("Tahoma", 7);

            dtImportar.Columns.Add(new DataColumn(" ", typeof(bool)));
            dtImportar.Columns.Add("Album", typeof(string));
            dtImportar.Columns.Add("Faixa", typeof(string));

        }
        private void CarregaGrdImportar()
        {

            foreach (var faixa in faixasImportar)
            {
                dtImportar.Rows.Add(new object[] { false, faixa.CaminhoArquivo, faixa.Titulo });
            }

            dtgImportar.DataSource = dtImportar;
        }
    }
}