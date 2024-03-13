using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcquestionarystate
    {
        public Tcquestionarystate()
        {
            Tcquestionaries = new HashSet<Tcquestionary>();
        }

        public int Cqsid { get; set; }
        public string Cqsdescription { get; set; } = null!;

        public virtual ICollection<Tcquestionary> Tcquestionaries { get; set; }
    }
}
