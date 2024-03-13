using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcquestionary
    {
        public int CqidQuestionary { get; set; }
        public int CqidUser { get; set; }
        public int Cqsid { get; set; }
        public int CqjpidJobProfile { get; set; }
        public string Cqresult { get; set; } = null!;
        public int Cqactive { get; set; }

        public virtual Tccandidate CqidUserNavigation { get; set; } = null!;
        public virtual Tcjobprofile CqjpidJobProfileNavigation { get; set; } = null!;
        public virtual Tcquestionarystate Cqs { get; set; } = null!;
    }
}
