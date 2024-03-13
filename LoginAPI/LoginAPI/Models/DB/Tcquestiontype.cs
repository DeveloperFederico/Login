using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcquestiontype
    {
        public Tcquestiontype()
        {
            Tcquestions = new HashSet<Tcquestion>();
        }

        public int Cqtid { get; set; }
        public string Cqtdescription { get; set; } = null!;

        public virtual ICollection<Tcquestion> Tcquestions { get; set; }
    }
}
