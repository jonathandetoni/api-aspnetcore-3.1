using System;

namespace Api.Domain.Dtos.CadastrosGerais.User.Results
{
    public class UserDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
