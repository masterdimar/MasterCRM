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
        public static List<AccountEN> GetAccounts(ref int iTotal
                                                    , ref int iTotalFiltered
                                                    , int iColumnSort
                                                    , string sSortDir)
        {
            List<AccountEN> oAccounts = new List<AccountEN>();            

            MasterCRMDatabase oEF = new MasterCRMDatabase();
            List<Cuenta> oCuentasEF = oEF.Cuentas.ToList<Cuenta>();

            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Cliente, ClienteEN>();
                cfg.CreateMap<Usuario, UsuarioEN>();
                cfg.CreateMap<SectorCuenta, AccountSectorEN>();
                cfg.CreateMap<TipoCuenta, AccountTypeEN>();
                cfg.CreateMap<Cuenta, AccountEN>()
                    .ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.Usuario));
            });

            AutoMapper.Mapper.Map(oCuentasEF, oAccounts);

            iTotal = oAccounts.Count();
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
