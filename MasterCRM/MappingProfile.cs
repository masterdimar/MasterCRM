using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using MasterCRM_Entities;
using MasterCRM.Models;
namespace MasterCRM
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountEN, AccountsGridModel>()
                  .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.Propietario.Apellido + " " + src.Propietario.Nombre));
        }        
    }
}