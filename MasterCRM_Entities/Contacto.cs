using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterCRM_Entities
{
    public class Contacto
    {
        public ClienteEN Cliente { get; set; }
        public int ContactoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Mobil { get; set; }
        public AccountEN Cuenta { get; set; }
        public UsuarioEN Propietario { get; set; }
    }
}
