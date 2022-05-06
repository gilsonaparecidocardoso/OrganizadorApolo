using System.Collections.Generic;

namespace OrganizadorApolo.Vagalume.JSON
{
    public class Root
    {
        public string Type { get; set; }
        public Art Art { get; set; }
        public List<Mu> Mus { get; set; }
        public bool Badwords { get; set; }
    }
}
