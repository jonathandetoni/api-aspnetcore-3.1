using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CadastrosGerais.User;
using Api.Domain.Entities.CadastrosGerais;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Service.Autenticacao;
using Api.Domain.Interfaces.Service.CadastrosGerais.User;
using Api.Domain.Models.CadastroGerais;
using AutoMapper;

namespace Api.Service.Services.CadastrosGerais
{
    public class UserService : IUserService
    {
        private ILoginService _loginService;
        private IRepository<UserEntity> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository,
                           IMapper mapper,
                           ILoginService loginService)
        {
            _repository = repository;
            _mapper = mapper;
            _loginService = loginService;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _repository.SelectAsync();

            return _mapper.Map<IEnumerable<UserDto>>(listEntity);
        }

        public async Task<UserDtoCreateResult> Post(UserDto user)
        {
            //Convertendo Dto em uma Model -> Controller para Service
            var model = _mapper.Map<UserModel>(user);

            byte[] passwordHash, passwordSalt;

            _loginService.CreatePasswordHash(user.Senha, out passwordHash, out passwordSalt);

            model.SenhaHash = passwordHash;
            model.SenhaSalt = passwordSalt;

            //Convertendo Model em Entidade -> Service para Data
            var entity = _mapper.Map<UserEntity>(model);

            //Passando a Entidade para o Banco de Dados -> Retorno do Banco
            var result = await _repository.InsertAsync(entity);

            //Convertendo a Entidade em um Result -> Entidade(Data) para Result 
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDto user)
        {
            var model = _mapper.Map<UserModel>(user);

            var entity = _mapper.Map<UserEntity>(model);

            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }
    }
}
