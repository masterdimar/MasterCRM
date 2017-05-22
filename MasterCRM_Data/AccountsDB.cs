using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MasterCRM_Entities;
namespace MasterCRM_Data
{
    public static class AccountsDB
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
            bool aAccountTypesEmpty = aAccountTypes.Length == 0 ? true : false;
            bool aAccountSectorsEmpty = aAccountSector.Length == 0 ? true : false;

            MasterCRMDatabase oEF = new MasterCRMDatabase();            
            IEnumerable<Cuenta> oCuentasEF = oEF.Cuentas;            
            iTotal = oCuentasEF.Count();

            oCuentasEF = oEF.Cuentas
                        .Where(CTA => 
                                        (CTA.Nombre.Contains(sAccountName) || String.IsNullOrEmpty(sAccountName))
                                        &&
                                        (aAccountTypesEmpty || aAccountTypes.Contains(CTA.TipoCuentaID))
                                        &&
                                        (aAccountSectorsEmpty || aAccountSector.Contains(CTA.SectorCuentaID))
                                        &&
                                        (CTA.Web.Contains(sWeb) || String.IsNullOrEmpty(sWeb))
                                        &&
                                        (CTA.Web.Contains(sOwner) || String.IsNullOrEmpty(sOwner))
                              )
                        ;

            List<AccountEN> oAccounts = AutomapperConfiguration.mapper.Map<List<AccountEN>>(oCuentasEF);

            iTotalFiltered = oAccounts.Count();

            switch (iColumnSort)
            {
                case 0:
                    if (sSortDir == "desc")
                        oAccounts = oAccounts.OrderByDescending(ACC => ACC.Nombre).ToList<AccountEN>();
                    else
                        oAccounts = oAccounts.OrderBy(ACC => ACC.Nombre).ToList<AccountEN>();
                    break;
                case 1:
                    if (sSortDir == "desc")
                        oAccounts = oAccounts.OrderByDescending(ACC => ACC.TipoCuenta.Descripcion).ToList<AccountEN>();
                    else
                        oAccounts = oAccounts.OrderBy(ACC => ACC.TipoCuenta.Descripcion).ToList<AccountEN>();
                    break;
                case 2:
                    if (sSortDir == "desc")
                        oAccounts = oAccounts.OrderByDescending(ACC => ACC.Web).ToList<AccountEN>();
                    else
                        oAccounts = oAccounts.OrderBy(ACC => ACC.Web).ToList<AccountEN>();
                    break;
                case 3:
                    if (sSortDir == "desc")
                        oAccounts = oAccounts.OrderByDescending(ACC => ACC.SectorCuenta.Descripcion).ToList<AccountEN>();
                    else
                        oAccounts = oAccounts.OrderBy(ACC => ACC.SectorCuenta.Descripcion).ToList<AccountEN>();
                    break;
                case 5:
                    if (sSortDir == "desc")
                        oAccounts = oAccounts.OrderByDescending(ACC => ACC.Propietario.Apellido).OrderByDescending(ACC => ACC.Propietario.Nombre).ToList<AccountEN>();
                    else
                        oAccounts = oAccounts.OrderBy(ACC => ACC.Propietario.Apellido).OrderBy(ACC => ACC.Propietario.Nombre).ToList<AccountEN>();
                    break;
            }

            return oAccounts;
        }
    }
}
