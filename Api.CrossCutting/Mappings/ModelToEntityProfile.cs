using Api.Domain.Entities.CadastrosGerais;
using Api.Domain.Models.CadastroGerais;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region Cadastros Geriais 
            CreateMap<UserEntity, UserModel>().ReverseMap();
            #endregion
        }
    }
}
