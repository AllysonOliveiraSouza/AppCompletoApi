namespace AppCompletoApi.Dtos
{
    public class SenhaDto
    {
        public int Id { get; set; }
        public string SenhaHash { get; set; }
        public int UsuarioId { get; set; }
    }
}
