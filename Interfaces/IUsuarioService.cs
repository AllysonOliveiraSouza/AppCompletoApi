using AppCompletoApi.Dtos;
using AppCompletoApi.Models;

namespace AppCompletoApi.Interfaces
{
    public interface IUsuarioService
    {
        public Usuario? Criar(UsuarioDto dto);
        public UsuarioDto Alterar(UsuarioDto dto);
        public RespostaDto Excluir(int id);
        public List<UsuarioDto> Listar();
        public UsuarioDto Obter(int id);
    }
}
