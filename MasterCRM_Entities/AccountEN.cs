using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCRM_Entities
{
    public class AccountEN
    {
        public ClienteEN Cliente { get; set; }
        public int CuentaID { get; set; }
        public string Nombre { get; set; }
        public AccountTypeEN TipoCuenta { get; set; }
        public AccountSectorEN SectorCuenta { get; set; }
        public string Web { get; set; }
        public string Telefono { get; set; }
        public int Empleados { get; set; }
        public UsuarioEN Propietario { get; set; }
    }
}
