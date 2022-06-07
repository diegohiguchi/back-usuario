using AutoMapper;
using Confitec.Core.DTOs;
using Confitec.Core.Entities;

namespace Confitec.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Escolaridade, EscolaridadeDTO>().ReverseMap();
            CreateMap<HistoricoEscolar, HistoricoEscolarDTO>().ReverseMap();
        }
    }
}
