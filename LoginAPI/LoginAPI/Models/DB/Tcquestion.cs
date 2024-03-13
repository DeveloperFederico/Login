using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcquestion
    {
        public Tcquestion()
        {
            Tcquestionaryquestions = new HashSet<Tcquestionaryquestion>();
        }

        public int CqidQuestion { get; set; }
        public string Cqdescription { get; set; } = null!;
        public int CqidTypeQuestion { get; set; }
        public int CqidJobProfile { get; set; }

        public virtual Tcjobprofile CqidJobProfileNavigation { get; set; } = null!;
        public virtual Tcquestiontype CqidTypeQuestionNavigation { get; set; } = null!;
        public virtual ICollection<Tcquestionaryquestion> Tcquestionaryquestions { get; set; }
    }
}
