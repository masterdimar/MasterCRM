using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MasterCRM_Entities;
using MasterCRM_Data;
namespace MasterCRM_BS
{
    public static class AccountTypesBS
    {
        public static List<AccountTypeEN> GetAccountTypes()
        {
            return AccountTypesDB.GetAccountTypes();
        }
    }
}
