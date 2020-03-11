using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Autenticacao
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é campo obrigatório para Login.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é campo obrigatório para Login.")]
        public string Senha { get; set; }
    }
}
