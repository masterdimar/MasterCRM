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
        public static List<AccountEN> GetAccounts(string sAccountName
                                                    , int[] aAccountTypes
                                                    , int[] aAccountSector
                                                    , string sWeb
                                                    , string sOwner
                                                    , ref int iTotal
                                                    , ref int iTotalFiltered
                                                    , int iColumnSort
                                                    , string sSortDir)
        {
            if (aAccountTypes == null)
                aAccountTypes = new int[0];

            if (aAccountSector == null)
                aAccountSector = new int[0];

            return AccountsDB.GetAccounts(sAccountName
                                            , aAccountTypes
                                            , aAccountSector
                                            , sWeb
                                            , sOwner
                                            , ref iTotal
                                            , ref iTotalFiltered
                                            , iColumnSort
                                            , sSortDir);
        }
    }
}
