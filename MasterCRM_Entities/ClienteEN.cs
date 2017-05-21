using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCRM_Entities
{
    public class ClienteEN
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public bool Demo { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Renovaciones { get; set; }
    }
}
