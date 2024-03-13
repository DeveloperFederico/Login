using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcrangeprofessional
    {
        public Tcrangeprofessional()
        {
            Tcjobprofiles = new HashSet<Tcjobprofile>();
        }

        public int CrpidRange { get; set; }
        public string Crpdescription { get; set; } = null!;

        public virtual ICollection<Tcjobprofile> Tcjobprofiles { get; set; }
    }
}
