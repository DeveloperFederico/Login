using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tclanguage
    {
        public Tclanguage()
        {
            Tcjobprofiles = new HashSet<Tcjobprofile>();
        }

        public int ClidLanguage { get; set; }
        public string Cldescription { get; set; } = null!;

        public virtual ICollection<Tcjobprofile> Tcjobprofiles { get; set; }
    }
}
