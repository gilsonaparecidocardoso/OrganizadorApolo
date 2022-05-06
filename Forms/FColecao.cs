using OrganizadorApolo.Models;
using OrganizadorApolo.Controllers.Log;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using OrganizadorApolo.Controllers.Database;
using OrganizadorApolo.Vagalume;

namespace OrganizadorApolo.Forms
{
    public partial class FColecao : Form
    {
        public string[] FilePaths { get; private set; }
        string[] files = null;
        MFaixa m = new MFaixa();

        public FColecao()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox2.Text = fbd.SelectedPath;
                    files = Directory.GetFiles(fbd.SelectedPath);
                    MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void CarregaDataGrid()
        {
            dataGridView1.Rows.Add(m.ArtistaParticipante, m.IdAlbum, m.Titulo, m.CaminhoArquivo);
        }

        //private void CarregaTreeview()
        //{
        //    treeView1.ImageList = il;

        //    // Cria o Nó Raiz (RootNode)
        //    TreeNode rootNode = treeView1.Nodes.Add("Brasil");
        //    rootNode.ImageIndex = 0;

        //    // Cria os nós filhos para o raiz
        //    TreeNode states1 = rootNode.Nodes.Add("São Paulo");
        //    states1.ImageIndex = 1;
        //    TreeNode states2 = rootNode.Nodes.Add("Goiás");
        //    states2.ImageIndex = 2;
        //    TreeNode states3 = rootNode.Nodes.Add("Rio de Janeiro");
        //    states3.ImageIndex = 3;
        //    TreeNode states4 = rootNode.Nodes.Add("Minas Gerais");
        //    states4.ImageIndex = 4;

        //    // Cria os nos descendentes para os nós filhos
        //    TreeNode child = states1.Nodes.Add("Campinas");
        //    child.ImageIndex = 5;
        //    child = states1.Nodes.Add("Jundiai");
        //    child.ImageIndex = 6;
        //    child = states1.Nodes.Add("Americana");
        //    child.ImageIndex = 7;

        //    child = states2.Nodes.Add("Luziânia");
        //    child.ImageIndex = 8;
        //    child = states2.Nodes.Add("Catalão");
        //    child.ImageIndex = 9;
        //    child = states2.Nodes.Add("Campo Bom");
        //    child.ImageIndex = 10;

        //    child = states3.Nodes.Add("Volta Redonda");
        //    child.ImageIndex = 11;
        //    child = states3.Nodes.Add("Campos");
        //    child.ImageIndex = 12;
        //    child = states3.Nodes.Add("Cabo Frio");
        //    child.ImageIndex = 13;

        //    child = states4.Nodes.Add("Frutal");
        //    child.ImageIndex = 14;
        //    child = states4.Nodes.Add("Itapagipe");
        //    child.ImageIndex = 15;
        //    child = states4.Nodes.Add("Uberaba");
        //    child.ImageIndex = 16;
        //}

        private void CarregaPictureBox(MFaixa _m)
        {
            try
            {
                //Image im = null;
                //IImagemDAO imagemDAO;

                //if (_m.Imagem != null)
                //{
                //    im = imagemDAO.ByteArrayToImage(_m.Imagem.Data.Data);

                //}
                //else
                //{
                //    im = imagemDAO.ByteArrayToImage(_m.Imagem.Data.Data);
                //}

                //if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
                //pictureBox1.Image = im;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.StackTrace);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            GeneroDAO dao = new GeneroDAO();
            comboBox1.DataSource = dao.RetornaTodosGeneros();
            comboBox1.DisplayMember = "descricaoGenero";
            comboBox1.ValueMember = "idGenero";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strID = ((MGenero)comboBox1.SelectedItem).IdGenero;
            string strName = ((MGenero)comboBox1.SelectedItem).DescricaoGenero;
        }

        private void FColecao_FormClosed(object sender, FormClosedEventArgs e)
        {
            MDIPrincipal.fColecao = null;
        }

        private void FColecao_Load(object sender, EventArgs e)
        {

        }


        //public void bibli_music()
        //{
        //    string path = (@"C:\Users\" + Environment.UserName + @"\Music");

        //    FilePaths = Directory.GetFiles(path, "*.mp3", SearchOption.AllDirectories);
        //    FilePaths2 = Directory.GetFiles(path, "*.flac", SearchOption.AllDirectories);
        //    FilePaths3 = Directory.GetFiles(path, "*.wav", SearchOption.AllDirectories);
        //    FilePaths4 = Directory.GetFiles(path, "*.ogg", SearchOption.AllDirectories);
        //    string[] z;
        //    z = new string[FilePaths.Count() + FilePaths2.Count()];
        //    FilePaths.CopyTo(z, 0);
        //    FilePaths2.CopyTo(z, FilePaths.Count());
        //    FilePaths = z;

        //    z = new string[FilePaths.Count() + FilePaths3.Count()];
        //    FilePaths.CopyTo(z, 0);
        //    FilePaths3.CopyTo(z, FilePaths.Count());
        //    FilePaths = z;

        //    z = new string[FilePaths.Count() + FilePaths4.Count()];
        //    FilePaths.CopyTo(z, 0);
        //    FilePaths4.CopyTo(z, FilePaths.Count());
        //    FilePaths = z;

        //    TagLib.File[] f;
        //    f = new TagLib.File[FilePaths.Count()];
        //    for (int i = 0; i < FilePaths.Count(); i++)
        //    {
        //        f[i] = TagLib.File.Create(FilePaths[i]);
        //    }
        //    var gridview = new GridView();
        //    this.bibView.View = gridview;
        //    gridview.Columns.Add(new GridViewColumn
        //    {
        //        Header = "Titre",
        //        DisplayMemberBinding = new Binding("Title")
        //    });
        //    gridview.Columns.Add(new GridViewColumn
        //    {
        //        Header = "Artiste",
        //        DisplayMemberBinding = new Binding("Artiste")
        //    });
        //    gridview.Columns.Add(new GridViewColumn
        //    {
        //        Header = "Album",
        //        DisplayMemberBinding = new Binding("Album")
        //    });
        //    for (int i = 0; i < FilePaths.Count(); i++)
        //    {
        //        bibView.Items.Add(new Song() { Title = f[i].Tag.Title, Artiste = f[i].Tag.FirstAlbumArtist, Album = f[i].Tag.Album });
        //        //listView.Items.Add(System.IO.Path.GetFileNameWithoutExtension(((MainWindow)this.Owner).med.chemin[i]));
        //    }

        //    //

        //}

        //public Media Create(String path)
        //{
        //    created = false;
        //    int point = path.LastIndexOf('.');
        //    if (point != -1)
        //    {
        //        String ext = path.Substring(point + 1);
        //        foreach (KeyValuePair<MediaType, Tuple<List<String>, object>> dic in AuthorizedExtension)
        //        {
        //            if (dic.Value.Item1.Contains(ext.ToLower()))
        //            {
        //                media = new Media();
        //                media.Type = dic.Key;
        //                created = true;
        //                Debug.Add("Media " + path + " created !");
        //            }
        //        }
        //    }
        //    if (!created)
        //        throw new InvalidMediaException(path + " is not a valid media");
        //    try
        //    {
        //        tag = null;
        //        tag = TagLib.File.Create(path);
        //    }
        //    catch (Exception e)
        //    {
        //        Debug.Add(e.ToString() + "\n");
        //    }
        //    media.AddTags(tag, path);
        //    media.CompleteData(AuthorizedExtension[media.Type].Item2);
        //    Debug.Add("Media datas completed !");
        //    return media;
        //}


    }
}
