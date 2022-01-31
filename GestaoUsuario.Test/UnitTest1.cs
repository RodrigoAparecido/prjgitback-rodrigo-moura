using Castle.Windsor;
using GestaoUsuario.API;
using GestaoUsuario.API.Controllers;
using GestaoUsuario.App.Interface;
using GestaoUsuario.App.RequestModel.Input.Token;
using GestaoUsuario.App.RequestModel.Input.Usuario;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;

namespace GestaoUsuario.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Token()
        {

            Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            IServiceCollection services = new ServiceCollection();
            var target = new Startup(Configuration.Object);
            target.ConfigureServices(services);
            services.AddTransient<TokenController>();
            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<TokenController>();

            ///var values = controller.Token(new TokenRequest { Login = "rodrigo.castro", Senha = "123545167890QQWERt!" });

            Assert.IsNotNull(controller);

        }

        [Test]
        public void validaSenha()
        {

            Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            IServiceCollection services = new ServiceCollection();
            var target = new Startup(Configuration.Object);
            target.ConfigureServices(services);
            services.AddTransient<UsuarioController>();
            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<UsuarioController>();

           // var values = controller.ValidarSenha(new UsuarioSenhaRequest { senha = "123545167890QQWERt!" });

            Assert.IsNotNull(controller);

        }

        [Test]
        public void CriaSenha()
        {

            Mock<Microsoft.Extensions.Configuration.IConfiguration> Configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>();
            IServiceCollection services = new ServiceCollection();
            var target = new Startup(Configuration.Object);
            target.ConfigureServices(services);
            services.AddTransient<UsuarioController>();
            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<UsuarioController>();

           // var values = controller.Incluir(new UsuarioPostRequest { Login ="Usuario.teste", PassWord = "123545167890QQWERt!" });

            Assert.IsNotNull(controller);

        }
    }
}