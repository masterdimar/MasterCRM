using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using MasterCRM_Entities;
using MasterCRM.Models;
namespace MasterCRM
{
    public static class AutomapperConfiguration
    {
        public static IMapper mapper;

        public static void Inicializar()
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<AccountEN, AccountsGridModel>()
                  .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Propietario.Apellido + " " + src.Propietario.Nombre))
                );

            mapper = config.CreateMapper();
        }
    }
}