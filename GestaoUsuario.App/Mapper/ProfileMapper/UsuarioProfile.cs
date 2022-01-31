using AutoMapper;
using GestaoUsuario.App.Model;
using GestaoUsuario.App.RequestModel.Input.Usuario;
using GestaoUsuario.Domain.Model;
using GestaoUsuario.Infra.Data;

namespace GestaoUsuario.App.Mapper.ProfileMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {

            CreateMap<UsuarioPostRequest, Usuario>()
                .ReverseMap();

            CreateMap<UsuarioPutRequest, Usuario>()
                .ReverseMap();
        }
    }
}