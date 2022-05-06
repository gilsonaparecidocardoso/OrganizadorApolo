using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace OrganizadorApolo.Forms
{
    public partial class FPlayer : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        string musica = @"C:\Users\Cardoso\Desktop\PASTA_MUSICAS\509-E\2000 - Provérbios 13\02 - Hora H.mp3";

        public FPlayer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(musica);
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            outputDevice?.Stop();
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackBar1.Scroll += (s, a) => outputDevice.Volume = trackBar1.Value / 100f;
        }

        private void FPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            MDIPrincipal.fPlayer = null;
        }
    }
}
