using AppCompletoApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace AppCompletoApi.Dtos
{
    public class CadastroDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [EmailValidation]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O gênero deve ser informado")]
        public string Sexo { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        public string Senha { get; set; }
    }
}
