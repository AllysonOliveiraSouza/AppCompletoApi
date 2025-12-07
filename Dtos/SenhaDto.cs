using System.ComponentModel.DataAnnotations;

namespace AppCompletoApi.Dtos
{
    public class SenhaDto
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "O id do usuário deve ser informado")]
        public int UsuarioId { get; set; }
    }
}
