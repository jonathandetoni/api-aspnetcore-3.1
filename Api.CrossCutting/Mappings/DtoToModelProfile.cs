using Api.Domain.Dtos.CadastrosGerais.User;
using Api.Domain.Models.CadastroGerais;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region Cadastros Gerais
            CreateMap<UserModel, UserDto>().ReverseMap();
            #endregion
        }
    }
}
