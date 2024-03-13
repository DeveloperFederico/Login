using System;
using System.Collections.Generic;

namespace LoginAPI.Models.DB
{
    public partial class Tcadministrator
    {
        public string Causer { get; set; } = null!;
        public string Capassword { get; set; } = null!;
        public DateTime CadateCreated { get; set; }
    }

}
