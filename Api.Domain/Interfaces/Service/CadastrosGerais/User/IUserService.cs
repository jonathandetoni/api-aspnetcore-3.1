using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CadastrosGerais.User;
using Api.Domain.Entities.CadastrosGerais;

namespace Api.Domain.Interfaces.Service.CadastrosGerais.User
{
    public interface IUserService
    {
        Task<UserDto> Get(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDtoCreateResult> Post(UserDto user);
        Task<UserDtoUpdateResult> Put(UserDto user);
        Task<bool> Delete(Guid id);
    }
}
