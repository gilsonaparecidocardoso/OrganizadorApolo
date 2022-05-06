namespace OrganizadorApolo.Forms
{
    partial class FColecao
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FColecao));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColArtista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAlbum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCaminho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(21, 353);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(165, 332);
            this.treeView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(420, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "C:\\Users\\Cardoso\\Desktop\\PASTA_MUSICAS\\509-E\\2000 - Provérbios 13\\02 - Hora H.mp3" +
    "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(682, 7);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(314, 340);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Vagalume";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(377, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "D:\\PASTA_MUSICAS";
            // 
            // button2
            // 
            this.button2.ImageIndex = 3;
            this.button2.Location = new System.Drawing.Point(447, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 23);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.ImageIndex = 5;
            this.button3.Location = new System.Drawing.Point(477, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 23);
            this.button3.TabIndex = 7;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(595, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(575, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "application.png");
            this.il.Images.SetKeyName(1, "application-warning_114485.png");
            this.il.Images.SetKeyName(2, "calculator_114411.png");
            this.il.Images.SetKeyName(3, "calendar_114417.png");
            this.il.Images.SetKeyName(4, "camera_114484.png");
            this.il.Images.SetKeyName(5, "clock_114442.png");
            this.il.Images.SetKeyName(6, "direction-down_114475.png");
            this.il.Images.SetKeyName(7, "direction-left_114422.png");
            this.il.Images.SetKeyName(8, "direction-right_114468.png");
            this.il.Images.SetKeyName(9, "direction-up_114481.png");
            this.il.Images.SetKeyName(10, "diskette_114482.png");
            this.il.Images.SetKeyName(11, "document_114447.png");
            this.il.Images.SetKeyName(12, "document-add_114467.png");
            this.il.Images.SetKeyName(13, "document-delete_114476.png");
            this.il.Images.SetKeyName(14, "document-edit_114472.png");
            this.il.Images.SetKeyName(15, "document-search_114446.png");
            this.il.Images.SetKeyName(16, "document-warning_114466.png");
            this.il.Images.SetKeyName(17, "file_114448.png");
            this.il.Images.SetKeyName(18, "file-add_114479.png");
            this.il.Images.SetKeyName(19, "file-delete_114438.png");
            this.il.Images.SetKeyName(20, "file-edit_114433.png");
            this.il.Images.SetKeyName(21, "file-search_114412.png");
            this.il.Images.SetKeyName(22, "file-warning_114449.png");
            this.il.Images.SetKeyName(23, "folder_114444.png");
            this.il.Images.SetKeyName(24, "folder-add_114459.png");
            this.il.Images.SetKeyName(25, "folder-delete_114435.png");
            this.il.Images.SetKeyName(26, "folder-empty_114452.png");
            this.il.Images.SetKeyName(27, "folder-search_114451.png");
            this.il.Images.SetKeyName(28, "folder-warning_114409.png");
            this.il.Images.SetKeyName(29, "load-download_114474.png");
            this.il.Images.SetKeyName(30, "load-upload_114462.png");
            this.il.Images.SetKeyName(31, "message_114430.png");
            this.il.Images.SetKeyName(32, "notification-add_114436.png");
            this.il.Images.SetKeyName(33, "notification-done_114461.png");
            this.il.Images.SetKeyName(34, "notification-error_114458.png");
            this.il.Images.SetKeyName(35, "notification-remove_114427.png");
            this.il.Images.SetKeyName(36, "notification-warning_114460.png");
            this.il.Images.SetKeyName(37, "piechart_114443.png");
            this.il.Images.SetKeyName(38, "player-fastforward_114421.png");
            this.il.Images.SetKeyName(39, "player-pause_114439.png");
            this.il.Images.SetKeyName(40, "player-play_114440.png");
            this.il.Images.SetKeyName(41, "player-record_114434.png");
            this.il.Images.SetKeyName(42, "player-rewind_114429.png");
            this.il.Images.SetKeyName(43, "player-stop_114486.png");
            this.il.Images.SetKeyName(44, "search_114478.png");
            this.il.Images.SetKeyName(45, "star-empty_114483.png");
            this.il.Images.SetKeyName(46, "star-full_114420.png");
            this.il.Images.SetKeyName(47, "star-half_114464.png");
            this.il.Images.SetKeyName(48, "user_114441.png");
            this.il.Images.SetKeyName(49, "user-add_114450.png");
            this.il.Images.SetKeyName(50, "user-delete_114455.png");
            this.il.Images.SetKeyName(51, "user-manage_114453.png");
            this.il.Images.SetKeyName(52, "user-warning_114415.png");
            this.il.Images.SetKeyName(53, "volume_114445.png");
            this.il.Images.SetKeyName(54, "volume-mute_114418.png");
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColArtista,
            this.ColAlbum,
            this.ColFaixa,
            this.ColCaminho});
            this.dataGridView1.Location = new System.Drawing.Point(21, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(655, 204);
            this.dataGridView1.TabIndex = 10;
            // 
            // ColArtista
            // 
            this.ColArtista.HeaderText = "Artista";
            this.ColArtista.Name = "ColArtista";
            // 
            // ColAlbum
            // 
            this.ColAlbum.HeaderText = "Álbum";
            this.ColAlbum.Name = "ColAlbum";
            // 
            // ColFaixa
            // 
            this.ColFaixa.HeaderText = "Faixa";
            this.ColFaixa.Name = "ColFaixa";
            // 
            // ColCaminho
            // 
            this.ColCaminho.HeaderText = "Caminho";
            this.ColCaminho.Name = "ColCaminho";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(447, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(54, 19);
            this.button4.TabIndex = 11;
            this.button4.Text = "Banco";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(172, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(269, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // FColecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FColecao";
            this.Text = "Coleção";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FColecao_FormClosed);
            this.Load += new System.EventHandler(this.FColecao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ImageList il;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColArtista;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColAlbum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCaminho;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

