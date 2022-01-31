using AutoMapper;
using GestaoUsuario.App.Mapper.ProfileMapper;
using System;

namespace GestaoUsuario.Infra.CrossCutting.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IConfigurationProvider Configure()
        {
            return new MapperConfiguration(ConfigAction);
        }

        public static Action<IMapperConfigurationExpression> ConfigAction = cfg =>
        {
            #region App

            cfg.AddProfile<UsuarioProfile>(); 
           
            #endregion

        };
    }
}
