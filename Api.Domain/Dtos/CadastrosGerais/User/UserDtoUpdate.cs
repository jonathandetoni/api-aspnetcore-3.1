using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.CadastrosGerais.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório para atualizar.")]
        public Guid Id { get; set; }

        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        [StringLength(100, ErrorMessage = "Email deve ter no máximo {1} caracteres.")]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
