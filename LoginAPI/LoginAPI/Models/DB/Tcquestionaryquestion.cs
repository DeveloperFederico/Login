using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcquestionaryquestion
    {
        public int CqqidQuestionary { get; set; }
        public int CqqidQuestion { get; set; }
        public string Cqqanswer { get; set; } = null!;

        public virtual Tcquestion CqqidQuestionNavigation { get; set; } = null!;
    }
}
