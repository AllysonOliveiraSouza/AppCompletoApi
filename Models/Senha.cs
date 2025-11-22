namespace AppCompletoApi.Models
{
    public class Senha
    {
        public int Id { get; set; }
        public string SenhaHash { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
