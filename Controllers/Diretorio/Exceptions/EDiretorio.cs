using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorApolo.Controllers.Diretorio.Exceptions
{
    [Serializable]
    public class EDiretorio : Exception
    {
        public EDiretorio()
        { }

        public EDiretorio(string _message) : base(_message)
        { }

        public EDiretorio(string _message, Exception _innerException) : base(_message, _innerException)
        { }
    }
}
