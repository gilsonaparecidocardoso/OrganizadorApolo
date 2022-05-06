using System;
using System.Windows.Forms;

namespace OrganizadorApolo.Forms
{
    public partial class MDIPrincipal : Form
    {
        private int childFormNumber = 0;
        public static FAlbum fAlbum;
        public static FPlayer fPlayer;
        public static FColecao fColecao;
        public static FImportarColecao fImportarColecao;
        public MDIPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Janela " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt|Todos os arquivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void novaBibliotecaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fColecao == null)
            {
                fColecao = new FColecao();
                fColecao.MdiParent = this;
                fColecao.WindowState = FormWindowState.Normal;
                fColecao.Show();
                fColecao.WindowState = FormWindowState.Maximized;
            }
        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fPlayer == null)
            {
                fPlayer = new FPlayer();
                fPlayer.MdiParent = this;
                fPlayer.WindowState = FormWindowState.Normal;
                fPlayer.Show();
                fPlayer.WindowState = FormWindowState.Maximized;
            }
        }

        private void albumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fAlbum == null)
            {
                fAlbum = new FAlbum(3);
                fAlbum.MdiParent = this;
                fAlbum.WindowState = FormWindowState.Normal;
                fAlbum.Show();
                fAlbum.WindowState = FormWindowState.Maximized;
            }
        }

        private void importarColeçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fImportarColecao == null)
            {
                fImportarColecao = new FImportarColecao();
                fImportarColecao.MdiParent = this;
                fImportarColecao.WindowState = FormWindowState.Normal;
                fImportarColecao.Show();
                fImportarColecao.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
