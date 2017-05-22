using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MasterCRM_Entities;
namespace MasterCRM_Data
{
    public static class AccountSectorsDB
    {
        public static List<AccountSectorEN> GetAccountSectors()
        {
            MasterCRMDatabase oEF = new MasterCRMDatabase();

            return AutomapperConfiguration.mapper.Map<List<AccountSectorEN>>(oEF.SectorCuentas);
        }
    }
}
