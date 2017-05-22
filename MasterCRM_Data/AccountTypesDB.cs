using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MasterCRM_Entities;
namespace MasterCRM_Data
{
    public static class AccountTypesDB
    {
        public static List<AccountTypeEN> GetAccountTypes()
        {
            MasterCRMDatabase oEF = new MasterCRMDatabase();
           
            return AutomapperConfiguration.mapper.Map<List<AccountTypeEN>>(oEF.TipoCuentas);
        }
    }
}
