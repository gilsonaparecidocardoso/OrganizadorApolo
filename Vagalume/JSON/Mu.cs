using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorApolo.Vagalume.JSON
{
    public class Mu
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int lang { get; set; }
        public string text { get; set; }
        public List<Translate> translate { get; set; }
    }
}
