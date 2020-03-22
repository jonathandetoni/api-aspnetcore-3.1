using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CadastrosGerais.User;
using Api.Domain.Dtos.CadastrosGerais.User.Results;

namespace Api.Domain.Interfaces.Service.CadastrosGerais.User
{
    public interface IUserService
    {
        Task<UserDtoList> Get(Guid id);
        Task<IEnumerable<UserDtoList>> GetAll();
        Task<UserDtoCreateResult> Post(UserDtoCreate user);
        Task<UserDtoUpdateResult> Put(UserDtoUpdate user);
        Task<bool> Delete(Guid id);
        Task<bool> CheckExistingEmail(string email);
    }
}
