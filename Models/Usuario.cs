namespace AppCompletoApi.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
