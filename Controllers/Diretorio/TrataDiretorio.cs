using OrganizadorApolo.APITagLib;
using OrganizadorApolo.Controllers.Log;
using OrganizadorApolo.Models;
using OrganizadorApolo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace OrganizadorApolo.Controllers.Diretorio
{
    public class TrataDiretorio : ITrataDiretorio
    {
        private List<MFaixa> mFaixas;
        private List<MAlbum> mAlbuns;
        private readonly CTagLib taglib;

        public TrataDiretorio()
        {
            mFaixas = new List<MFaixa>();
            taglib = new CTagLib();
        }

        public void CopyMatching(string drive)
        {
            try
            {
                var backuplocation = ""; //the path where you wanna copy your files to
                var regex = new Regex(@"[A-Z]:\\Folder[0-9]{1}\\Folder[0-9]{2}\\Folder[0-9]{3}");
                var directories = new List<string>();
                foreach (var directory in Directory.EnumerateDirectories(drive))
                {
                    if (regex.IsMatch(directory))
                    {
                        directories.Add(directory);
                    }
                }
                foreach (var directory in directories)
                {
                    DirectoryCopy(directory, backuplocation, true);
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Classe: " + this.GetType() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }
        }

        /// <summary>
        /// aA
        /// </summary>
        /// <param name="_diretorio"></param>
        /// <returns></returns>
        public List<MAlbum> RetornaAlbunsDoDiretorio(string _diretorio)
        {
            List<string> faixas = RetornaArquivoPorFiltro(_diretorio, "*.mp3");

            mAlbuns = taglib.RetornaID3(faixas.ToArray());

            return mAlbuns;
        }

        public void DirectoryCopy(string _sourceDirName, string _destDirName, bool _copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(_sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + _sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(_destDirName))
            {
                Directory.CreateDirectory(_destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(_destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (_copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(_destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, _copySubDirs);
                }
            }
        }

        /// <summary>
        /// Retorna um diretório acima do informado.
        /// </summary>
        /// <param name="_path"></param>
        /// <returns></returns>
        internal string RetornaPastaNivelAcima(string _path)
        {
            try
            {
                return Directory.GetParent(_path).FullName;
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Classe: " + this.GetType() + "\n" +
                                "> StackTrace: " + ex.StackTrace);

                return null;
            }
        }

        /// <summary>
        /// Pesquisa no diretório informado os arquivos por extensão.
        /// </summary>
        /// <param name="_path">Pasta a ser pesquisada.</param>
        /// <param name="_pattern">Extensão do arquivo.
        /// Ex: trataDiretorio.RetornaPastaMusica(faixas[0].CaminhoArquivo), "*.jpg");</param>
        /// <returns>Retorna um vetor de strings contendo os diretórios dos arquivos pesquisados.</returns>
        public List<string> RetornaArquivoPorFiltro(string _path, string _pattern)
        {
            List<string> filePaths = new List<string>();
            try
            {
                foreach (var item in Directory.GetFiles(_path, _pattern, SearchOption.AllDirectories))
                {
                    filePaths.Add(item);
                }
                filePaths = RemoveArquivosFalsos(filePaths);
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Classe: " + this.GetType() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return filePaths;
        }

        /// <summary>
        /// Remove os arquivos que contenham ".db" e "._" no nome.
        /// </summary>
        /// <param name="_filePaths"></param>
        /// <returns>Retorna um string[] contendo os arquivos sem os arquivos falsos.</returns>
        private List<string> RemoveArquivosFalsos(List<string> _filePaths)
        {
            List<string> arquivos = new List<string>();

            try
            {
                foreach (var item in _filePaths)
                {
                    if (!item.Contains(".db") && !item.Contains("._"))
                    {
                        arquivos.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                RegistraLog.Log("> Classe: " + this.GetType() + "\n" +
                                "> StackTrace: " + ex.StackTrace);
            }

            return arquivos;
        }
    }
}
