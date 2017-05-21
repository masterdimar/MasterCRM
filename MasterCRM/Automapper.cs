using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MasterCRM_Entities;
using MasterCRM.Models;
namespace MasterCRM
{
    public static class Automapper
    {
        public static void Inicializar()
        {
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<AccountEN, AccountsGridModel>()
                  .ForMember(dest => dest.AccountID, opt => opt.MapFrom(src => src.CuentaID))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nombre))
                  .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Propietario.Apellido + " " + src.Propietario.Nombre))
                  .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.SectorCuenta.Descripcion))
                  .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.TipoCuenta.Descripcion))
                  .ForMember(dest => dest.Web, opt => opt.MapFrom(src => src.Web));
            });
        }
    }
}