
namespace OrganizadorApolo.Forms
{
    partial class FImportarColecao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtgImportar = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnListar = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.btnDesmarca = new System.Windows.Forms.Button();
            this.btnQuais = new System.Windows.Forms.Button();
            this.btnCarregaInfo = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgImportar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgImportar
            // 
            this.dtgImportar.AllowUserToAddRows = false;
            this.dtgImportar.AllowUserToDeleteRows = false;
            this.dtgImportar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgImportar.Location = new System.Drawing.Point(15, 51);
            this.dtgImportar.Name = "dtgImportar";
            this.dtgImportar.Size = new System.Drawing.Size(501, 387);
            this.dtgImportar.TabIndex = 0;
            this.dtgImportar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgImportar_CellClick);
            this.dtgImportar.Click += new System.EventHandler(this.dtgImportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Caminho da coleção:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(522, 89);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(35, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "label2";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(498, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "C:\\Users\\Cardoso\\Desktop\\PASTA_MUSICAS";
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(525, 22);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 23);
            this.btnListar.TabIndex = 4;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.BtnListar_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(606, 22);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(75, 23);
            this.btnMarca.TabIndex = 5;
            this.btnMarca.Text = "Marca";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.BtnMarcar_Click);
            // 
            // btnDesmarca
            // 
            this.btnDesmarca.Location = new System.Drawing.Point(687, 22);
            this.btnDesmarca.Name = "btnDesmarca";
            this.btnDesmarca.Size = new System.Drawing.Size(75, 23);
            this.btnDesmarca.TabIndex = 6;
            this.btnDesmarca.Text = "Desmarca";
            this.btnDesmarca.UseVisualStyleBackColor = true;
            this.btnDesmarca.Click += new System.EventHandler(this.BtnDesmarcar_Click);
            // 
            // btnQuais
            // 
            this.btnQuais.Location = new System.Drawing.Point(695, 121);
            this.btnQuais.Name = "btnQuais";
            this.btnQuais.Size = new System.Drawing.Size(75, 23);
            this.btnQuais.TabIndex = 7;
            this.btnQuais.Text = "Quais Selecionados";
            this.btnQuais.UseVisualStyleBackColor = true;
            this.btnQuais.Click += new System.EventHandler(this.BtnQuais_Click);
            // 
            // btnCarregaInfo
            // 
            this.btnCarregaInfo.Location = new System.Drawing.Point(525, 252);
            this.btnCarregaInfo.Name = "btnCarregaInfo";
            this.btnCarregaInfo.Size = new System.Drawing.Size(75, 23);
            this.btnCarregaInfo.TabIndex = 8;
            this.btnCarregaInfo.Text = "Info";
            this.btnCarregaInfo.UseVisualStyleBackColor = true;
            this.btnCarregaInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // FImportarColecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCarregaInfo);
            this.Controls.Add(this.btnQuais);
            this.Controls.Add(this.btnDesmarca);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgImportar);
            this.Name = "FImportarColecao";
            this.Text = "Importar Coleção";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FImportarColecao_FormClosed);
            this.Load += new System.EventHandler(this.FImportarColecao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgImportar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgImportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button btnDesmarca;
        private System.Windows.Forms.Button btnQuais;
        private System.Windows.Forms.Button btnCarregaInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}