using System.Text.Json.Serialization;

namespace AppCompletoApi.Models
{
    public class TipoUsuario
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        [JsonIgnore]
        public List<Usuario> Usuarios { get; set; } = [];
    }
}
