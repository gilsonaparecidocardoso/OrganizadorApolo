using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OrganizadorApolo.Controllers.Log
{
    public static class RegistraLog
    {
        private static string caminhoExe = "D:\\Log"; //Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static bool Log(string strMensagem, string strNomeArquivo = "ArquivoLog.txt")
        {
            try
            {
                
                string caminhoArquivo = Path.Combine(caminhoExe, strNomeArquivo);
                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }
                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    AppendLog(strMensagem, w);
                }
                CapturaTela();
                return true;
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.StackTrace);
                return false;
            }
        }

        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entrada : ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine($"  :{logMensagem}");
                txtWriter.WriteLine("------------------------------------");
            }
            catch (Exception ex)
            {
                RegistraLog.Log(ex.StackTrace);
            }
        }
        private static void CapturaTela()
        {
            PictureBox pctCaptura = new PictureBox();
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using (Graphics graph = Graphics.FromImage(bitmap as Image))
            {
                graph.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
            }

            pctCaptura.Image?.Dispose();
            pctCaptura.Image = bitmap;
            pctCaptura.Image.Save(Path.Combine(caminhoExe, "Captura.jpg"));
        }
    }
}
