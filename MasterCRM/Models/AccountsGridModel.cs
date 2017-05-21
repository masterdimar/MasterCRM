using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCRM.Models
{
    public class AccountsGridModel
    {
        public int AccountID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Web { get; set; }
        public string Sector { get; set; }
        public string Owner { get; set; }
    }
}