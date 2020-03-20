using Api.Domain.Interfaces.Service.Autenticacao;
using Api.Domain.Interfaces.Service.CadastrosGerais.User;
using Api.Service.Services.Autenticacao;
using Api.Service.Services.CadastrosGerais;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
