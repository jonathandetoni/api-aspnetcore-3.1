namespace Api.Domain.Entities.CadastrosGerais
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
    }
}
