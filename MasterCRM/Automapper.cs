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
                  .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Propietario.Apellido + " " + src.Propietario.Nombre));
            });
        }
    }
}