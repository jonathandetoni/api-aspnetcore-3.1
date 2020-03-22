using Api.Domain.Dtos.CadastrosGerais.User;
using Api.Domain.Dtos.CadastrosGerais.User.Results;
using Api.Domain.Entities.CadastrosGerais;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region Cadastro Gerais 

            #region User
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
            #endregion

            #endregion
        }
    }
}
