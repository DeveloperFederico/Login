using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tccandidate
    {
        public Tccandidate()
        {
            Tcquestionaries = new HashSet<Tcquestionary>();
        }

        public int CcidUser { get; set; }
        public string Ccnames { get; set; } = null!;
        public string CclastName { get; set; } = null!;
        public string Ccmobile { get; set; } = null!;
        public string Ccemail { get; set; } = null!;

        public virtual ICollection<Tcquestionary> Tcquestionaries { get; set; }
    }
}
