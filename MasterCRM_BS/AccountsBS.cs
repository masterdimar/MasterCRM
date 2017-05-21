using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MasterCRM_Entities;
using MasterCRM_Data;
namespace MasterCRM_BS
{
    public static class AccountsBS
    {
        public static List<AccountEN> GetAccounts(ref int iTotal
                                                    , ref int iTotalFiltered
                                                    , int iColumnSort
                                                    , string sSortDir)
        {
            return AccountsDB.GetAccounts(ref iTotal, ref iTotalFiltered, iColumnSort, sSortDir);
        }
    }
}
