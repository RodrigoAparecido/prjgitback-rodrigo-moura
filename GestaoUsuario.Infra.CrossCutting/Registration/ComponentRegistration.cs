using AutoMapper;
using GestaoUsuario.App.Interface;
using GestaoUsuario.App.Service;
using GestaoUsuario.Domain.Interface.Handler;
using GestaoUsuario.Domain.Interface.Repository;
using GestaoUsuario.Domain.Interface.Service;
using GestaoUsuario.Domain.Service;
using GestaoUsuario.Infra.CrossCutting.Configuration;
using GestaoUsuario.Infra.CrossCutting.Handler;
using GestaoUsuario.Infra.CrossCutting.Interceptor;
using GestaoUsuario.Infra.Data.DataBase.Context;
using GestaoUsuario.Infra.Data.Repository;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestaoUsuario.Infra.CrossCutting.Registration
{
    public class ComponentRegistration
    {
        private static IWindsorContainer _windsorContainer;

        public static void Register(IServiceCollection services, IWindsorContainer windsorContainer, IConfiguration configuration)
        {
            if (windsorContainer is null)
                windsorContainer = new WindsorContainer();

            RegisterInfraCrossCutting(services, windsorContainer, configuration);
            RegisterInfraData(services, windsorContainer, configuration);
            RegisterDomain(services, windsorContainer, configuration);
            RegisterApp(services, windsorContainer, configuration);

            _windsorContainer = windsorContainer;

            var serviceProvider = WindsorRegistrationHelper.CreateServiceProvider(
                windsorContainer,
                services);
        }

        private static void RegisterInfraCrossCutting(IServiceCollection services, IWindsorContainer windsorContainer, IConfiguration configuration)
        {
            windsorContainer.Register(
                Component.For<IResponseErrorHandle>()
                .ImplementedBy<ResponseErrorHandle>()
                .LifestyleTransient()
                );

            windsorContainer.Register(
                Component.For<DomainMethodInterceptor>()
                .ImplementedBy<DomainMethodInterceptor>()
                .LifestyleTransient()
                );

            windsorContainer.Register(
                Component.For<AppMethodInterceptor>()
                .ImplementedBy<AppMethodInterceptor>()
                .LifestyleTransient()
                );

           
        }


        private static void RegisterInfraData(IServiceCollection services, IWindsorContainer windsorContainer, IConfiguration configuration)
        {
            var mySqlConnectionStr = configuration.GetConnectionString("GestaoUsuarioSql");

            services.AddDbContext<GestaoUsuarioContext>(options =>
            {
                options.UseSqlServer(mySqlConnectionStr);
                options.UseLazyLoadingProxies(false);
            }, ServiceLifetime.Transient);

            windsorContainer.Register(
                Component.For<IUsuarioRepository>()
                .ImplementedBy<UsuarioRepository>()
                .LifestyleTransient()
                );

            windsorContainer.Register(
               Component.For<IUsuarioReadOnlyRepository>()
               .ImplementedBy<UsuarioReadOnlyRepository>()
               .LifestyleTransient()
               );
        }

        private static void RegisterDomain(IServiceCollection services, IWindsorContainer windsorContainer, IConfiguration configuration)
        {

            windsorContainer.Register(
                Component.For<IUsuarioService>()
                .ImplementedBy<UsuarioService>()
                .Interceptors(InterceptorReference.ForType<DomainMethodInterceptor>()).Anywhere
                .LifestyleTransient()
                );
        }

        private static void RegisterApp(IServiceCollection services, IWindsorContainer windsorContainer, IConfiguration configuration)
        {
            windsorContainer.Register(
                Component.For<IMapper>()
                .UsingFactoryMethod(kernel => new Mapper(AutoMapperConfiguration.Configure())));

            windsorContainer.Register(
                Component.For<IUsuarioServiceApp>()
                .ImplementedBy<UsuarioServiceApp>()
                .Interceptors(InterceptorReference.ForType<AppMethodInterceptor>()).Anywhere
                .LifestyleTransient()
                );
        }

        public static T For<T>()
        {
            return _windsorContainer.Resolve<T>();
        }
    }
}
