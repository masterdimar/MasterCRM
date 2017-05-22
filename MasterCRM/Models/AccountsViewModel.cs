using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCRM.Models
{
    public class AccountsViewModel
    {
        public List<DropdownlistModel> Sectores { get; set; }
        public List<DropdownlistModel> Tipos { get; set; }
    }
}