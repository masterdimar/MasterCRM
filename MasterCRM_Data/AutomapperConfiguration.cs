using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using MasterCRM_Entities;
namespace MasterCRM_Data
{
    public static class AutomapperConfiguration
    {
        public static IMapper mapper;

        public static void Inicializar()
        {
            var config = new MapperConfiguration(cfg =>
            {                
                cfg.CreateMap<Cliente, ClienteEN>();

                cfg.CreateMap<Cuenta, AccountEN>()
                    .ForMember(dest => dest.Propietario, opt => opt.MapFrom(src => src.Usuario));

                cfg.CreateMap<SectorCuenta, AccountSectorEN>();
                cfg.CreateMap<TipoCuenta, AccountTypeEN>();               
                cfg.CreateMap<Usuario, UsuarioEN>();
            });

            mapper = config.CreateMapper();
        }
    }
}
