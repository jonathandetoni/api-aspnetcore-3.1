using System.Threading.Tasks;
using Api.Domain.Dtos.Autenticacao;
using Api.Domain.Entities.CadastrosGerais;

namespace Api.Domain.Interfaces.Service.Autenticacao
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
