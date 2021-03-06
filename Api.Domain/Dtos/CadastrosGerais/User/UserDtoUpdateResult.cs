using System;

namespace Api.Domain.Dtos.CadastrosGerais.User
{
    public class UserDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
