using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCRM.Models
{
    public class AccountsAddEditModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int OwnerID { get; set; }
        public int? SectorID { get; set; }
        public int? TipoID { get; set; }
        public string Web { get; set; }
    }
}