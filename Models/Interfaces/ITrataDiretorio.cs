using System.Collections.Generic;

namespace OrganizadorApolo.Models.Interfaces
{
    public interface ITrataDiretorio
    {
        void CopyMatching(string _drive);
        void DirectoryCopy(string _sourceDirName, string _destDirName, bool _copySubDirs);
        List<string> RetornaArquivoPorFiltro(string _path, string _pattern);
    }
}
