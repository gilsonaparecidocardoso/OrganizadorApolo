using OrganizadorApolo.Controllers;
using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Controllers.Diretorio;
using OrganizadorApolo.Models;
using OrganizadorApolo.Vagalume;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OrganizadorApolo.Forms
{
    public partial class FAlbum : Form
    {
        private readonly MAlbum album;

        private readonly CArtista cArtista;
        private readonly MArtista artista;

        private readonly CFaixa cFaixa;
        private readonly List<MFaixa> faixas;

        private readonly TrataDiretorio trataDiretorio = new TrataDiretorio();

        private List<string> diretoriosFiltroImagens;
        private int contImagem = 0;

        private readonly APIVagalume v = new APIVagalume();

        DataTable dtFaixas = new DataTable();

        public FAlbum(int _idAlbum)
        {
            InitializeComponent();
            
            album = new MAlbum(_idAlbum);
            
            cArtista = new CArtista(new ArtistaDAO());
            //artista = cArtista.RetornaArtistaPorId(album.Artista.IdArtista);

            cFaixa = new CFaixa(new FaixaDAO());
            //faixas = cFaixa.RetornaFaixaPorIdAlbum(_idAlbum);
            faixas = album.Faixas;

            CarregaImagem();

            CarregaGridFaixas();
        }
        
        private void CarregaImagem()
        {
            string pasta = trataDiretorio.RetornaPastaNivelAcima(faixas[0].CaminhoArquivo);
            if(pasta != "")
            {
                diretoriosFiltroImagens = trataDiretorio.RetornaArquivoPorFiltro(pasta, "*.jpg");
                pctImagem.Image = Image.FromFile(diretoriosFiltroImagens[0]);
            }
            
            //string[] diretorios = trataDiretorio.RetornaArquivoPorFiltro(PastaMusica, "*.bmp");
            //diretorios = trataDiretorio.RetornaArquivoPorFiltro(PastaMusica, "*.png");
            //diretorios = trataDiretorio.RetornaArquivoPorFiltro(PastaMusica, "*.gif");
        }

        private void CarregaGridFaixas()
        {
            dtFaixas.Columns.Add("Nro", typeof(int)); 
            dtFaixas.Columns.Add("Título", typeof(string));
            dtFaixas.Columns.Add("Duração", typeof(string));
            dtFaixas.Columns.Add("Tamanho", typeof(string));
            dtFaixas.Columns.Add("Caminho do Arquivo", typeof(string));

            foreach (var faixa in faixas)
            {
                dtFaixas.Rows.Add(new object[] { faixa.NroFaixa, faixa.Titulo, faixa.Duracao, faixa.Tamanho, faixa.CaminhoArquivo });
            }
            
            dataGridView1.DataSource = dtFaixas;            
        }

        private void Album_Load(object sender, EventArgs e)
        {
            AddToolStripLabel("Diretório: ");

            if (faixas.Count > 0)
            {
                AddToolStripButtons(this.faixas[0].CaminhoArquivo.Split('\\'));
            }
            else
            {
                AddToolStripButtons(new string[] { "C:\\" });
            }
        }

        private void AddToolStripLabel(string _diretorio)
        {
            ToolStripLabel tsl = new ToolStripLabel();
            tsl.Text = _diretorio;
            tsl.Tag = _diretorio;
            tsl.Click += Tsb_Click;
            toolStrip1.Items.Add(tsl);
        }

        private void AddToolStripButtons(string[] _diretorios)
        {
            //_diretorios.Length - 1 - Retira a faixa.mp3
            for (int i = 0; i < _diretorios.Length - 1; i++)
            {
                string pasta = _diretorios[i];
                ToolStripButton tsb = new ToolStripButton();

                if(i == _diretorios.Length - 1)
                {
                    tsb.Text = pasta;
                }
                else
                {
                    tsb.Text = pasta + "\\";
                }
                
                tsb.Image = Bitmap.FromFile("C:\\Users\\Cardoso\\Desktop\\icones\\24\\folder_Open_32xLG.png");
                tsb.Tag = pasta;
                tsb.Click += Tsb_Click;
                toolStrip1.Items.Add(tsb);
            }
        }
        private void Tsb_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            if (tsb != null && tsb.Tag != null)
                MessageBox.Show(String.Format("Hello im the {0} button", tsb.Tag.ToString()));
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            if (contImagem == 0)
            {
                contImagem = diretoriosFiltroImagens.Count - 1;
                pctImagem.Image = Image.FromFile(diretoriosFiltroImagens[contImagem]);
            }
            else
            {
                pctImagem.Image = Image.FromFile(diretoriosFiltroImagens[--contImagem]);
            }
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            if(contImagem < diretoriosFiltroImagens.Count - 1)
            {
                pctImagem.Image = Image.FromFile(diretoriosFiltroImagens[++contImagem]);
            }  
            else
            {
                contImagem = -1;
                pctImagem.Image = Image.FromFile(diretoriosFiltroImagens[++contImagem]);
            }
        }

        private void FAlbum_FormClosed(object sender, FormClosedEventArgs e)
        {
            MDIPrincipal.fAlbum = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Menu: " + sender.GetType();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        }

        private void Button3_Click(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dtFaixas.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Título", textBox1.Text);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["Título"].Value != null)
            {
                string titulo = dataGridView1.Rows[e.RowIndex].Cells["Título"].Value.ToString();

                foreach (var item in album.Faixas)
                {
                    if (titulo == item.Titulo)
                    {
                        if (item.Letra.Length == 0)
                        {
                            string l = v.RetornaLetraPorArtistaETitulo(artista.Artista, titulo);
                            if(l != "")
                            {
                                item.Letra = l;
                                cFaixa.IncluirLetra(item);
                            }
                        }

                        MostraLetra(item.Letra);
                    }
                }
            }
        }

        private void MostraLetra(string v)
        {
            richTextBox1.Text = v;
        }
    }
}
