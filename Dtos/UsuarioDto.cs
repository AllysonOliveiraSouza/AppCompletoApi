using AppCompletoApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace AppCompletoApi.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }
        [EmailValidation]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O gênero deve ser informado")]
        public string Sexo { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
