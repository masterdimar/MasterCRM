using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterCRM.Models
{
    public class AccountsGridModel
    {
        public int CuentaID { get; set; }
        public string Nombre { get; set; }
        public string TipoCuentaDescripcion { get; set; }
        public string Web { get; set; }
        public string SectorCuentaDescripcion { get; set; }
        public string Owner { get; set; }
    }
}