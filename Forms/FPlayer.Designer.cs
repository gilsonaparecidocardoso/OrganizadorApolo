
namespace OrganizadorApolo.Forms
{
    partial class FPlayer
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
            this.waveViewer1 = new NAudio.Gui.WaveViewer();
            this.fader1 = new NAudio.Gui.Fader();
            this.volumeSlider1 = new NAudio.Gui.VolumeSlider();
            this.volumeMeter1 = new NAudio.Gui.VolumeMeter();
            this.progressLog1 = new NAudio.Utils.ProgressLog();
            this.pot1 = new NAudio.Gui.Pot();
            this.panSlider1 = new NAudio.Gui.PanSlider();
            this.fader2 = new NAudio.Gui.Fader();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // waveViewer1
            // 
            this.waveViewer1.Location = new System.Drawing.Point(12, 369);
            this.waveViewer1.Name = "waveViewer1";
            this.waveViewer1.SamplesPerPixel = 128;
            this.waveViewer1.Size = new System.Drawing.Size(381, 69);
            this.waveViewer1.StartPosition = ((long)(0));
            this.waveViewer1.TabIndex = 0;
            this.waveViewer1.WaveStream = null;
            // 
            // fader1
            // 
            this.fader1.Location = new System.Drawing.Point(399, 369);
            this.fader1.Maximum = 0;
            this.fader1.Minimum = 0;
            this.fader1.Name = "fader1";
            this.fader1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.fader1.Size = new System.Drawing.Size(389, 69);
            this.fader1.TabIndex = 1;
            this.fader1.Text = "fader1";
            this.fader1.Value = -2147483648;
            // 
            // volumeSlider1
            // 
            this.volumeSlider1.Location = new System.Drawing.Point(403, 301);
            this.volumeSlider1.Name = "volumeSlider1";
            this.volumeSlider1.Size = new System.Drawing.Size(94, 42);
            this.volumeSlider1.TabIndex = 2;
            // 
            // volumeMeter1
            // 
            this.volumeMeter1.Amplitude = 0F;
            this.volumeMeter1.Location = new System.Drawing.Point(511, 301);
            this.volumeMeter1.MaxDb = 18F;
            this.volumeMeter1.MinDb = -60F;
            this.volumeMeter1.Name = "volumeMeter1";
            this.volumeMeter1.Size = new System.Drawing.Size(107, 41);
            this.volumeMeter1.TabIndex = 3;
            this.volumeMeter1.Text = "volumeMeter1";
            // 
            // progressLog1
            // 
            this.progressLog1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.progressLog1.Location = new System.Drawing.Point(409, 255);
            this.progressLog1.Name = "progressLog1";
            this.progressLog1.Padding = new System.Windows.Forms.Padding(1);
            this.progressLog1.Size = new System.Drawing.Size(378, 21);
            this.progressLog1.TabIndex = 4;
            // 
            // pot1
            // 
            this.pot1.Location = new System.Drawing.Point(399, 92);
            this.pot1.Maximum = 1D;
            this.pot1.Minimum = 0D;
            this.pot1.Name = "pot1";
            this.pot1.Size = new System.Drawing.Size(174, 73);
            this.pot1.TabIndex = 5;
            this.pot1.Value = 0.5D;
            // 
            // panSlider1
            // 
            this.panSlider1.Location = new System.Drawing.Point(403, 171);
            this.panSlider1.Name = "panSlider1";
            this.panSlider1.Pan = 0F;
            this.panSlider1.Size = new System.Drawing.Size(249, 77);
            this.panSlider1.TabIndex = 6;
            // 
            // fader2
            // 
            this.fader2.Location = new System.Drawing.Point(29, 82);
            this.fader2.Maximum = 0;
            this.fader2.Minimum = 0;
            this.fader2.Name = "fader2";
            this.fader2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.fader2.Size = new System.Drawing.Size(300, 118);
            this.fader2.TabIndex = 7;
            this.fader2.Text = "fader2";
            this.fader2.Value = -2147483648;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(355, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(400, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 22);
            this.button2.TabIndex = 9;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(450, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 22);
            this.button3.TabIndex = 10;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(602, 26);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(125, 45);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // FPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fader2);
            this.Controls.Add(this.panSlider1);
            this.Controls.Add(this.pot1);
            this.Controls.Add(this.progressLog1);
            this.Controls.Add(this.volumeMeter1);
            this.Controls.Add(this.volumeSlider1);
            this.Controls.Add(this.fader1);
            this.Controls.Add(this.waveViewer1);
            this.Name = "FPlayer";
            this.Text = "FrmPlayer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FPlayer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NAudio.Gui.WaveViewer waveViewer1;
        private NAudio.Gui.Fader fader1;
        private NAudio.Gui.VolumeSlider volumeSlider1;
        private NAudio.Gui.VolumeMeter volumeMeter1;
        private NAudio.Utils.ProgressLog progressLog1;
        private NAudio.Gui.Pot pot1;
        private NAudio.Gui.PanSlider panSlider1;
        private NAudio.Gui.Fader fader2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}