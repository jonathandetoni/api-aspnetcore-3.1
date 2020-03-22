using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Dtos.CadastrosGerais.User;
using Api.Domain.Entities.CadastrosGerais;
using Api.Domain.Interfaces.Service.Autenticacao;
using Api.Domain.Interfaces.Service.CadastrosGerais.User;
using Api.Domain.Models.CadastroGerais;
using Api.Domain.Repository.CadastrosGerais;
using AutoMapper;

namespace Api.Service.Services.CadastrosGerais
{
    public class UserService : IUserService
    {
        private ILoginService _loginService;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IMapper mapper,
                           ILoginService loginService,
                           IUserRepository userRepository)
        {
            _mapper = mapper;
            _loginService = loginService;
            _userRepository = userRepository;

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _userRepository.SelectAsync(id);

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var listEntity = await _userRepository.SelectAsync();

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
            var result = await _userRepository.InsertAsync(entity);

            //Convertendo a Entidade em um Result -> Entidade(Data) para Result 
            return _mapper.Map<UserDtoCreateResult>(result);
        }

        public async Task<UserDtoUpdateResult> Put(UserDto user)
        {
            var model = _mapper.Map<UserModel>(user);

            var entity = _mapper.Map<UserEntity>(model);

            var result = await _userRepository.UpdateAsync(entity);

            return _mapper.Map<UserDtoUpdateResult>(result);
        }

        public async Task<bool> CheckExistingEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            var result = await _userRepository.CheckExistingEmail(email);

            if (result)
            {
                return true;
            }

            return false;
        }
    }
}
