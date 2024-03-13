using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcjobprofile
    {
        public Tcjobprofile()
        {
            Tcquestionaries = new HashSet<Tcquestionary>();
            Tcquestions = new HashSet<Tcquestion>();
        }

        public int CjpidJobProfile { get; set; }
        public int CjpidRange { get; set; }
        public int CjpidLanguage { get; set; }

        public virtual Tclanguage CjpidLanguageNavigation { get; set; } = null!;
        public virtual Tcrangeprofessional CjpidRangeNavigation { get; set; } = null!;
        public virtual ICollection<Tcquestionary> Tcquestionaries { get; set; }
        public virtual ICollection<Tcquestion> Tcquestions { get; set; }
    }
}
