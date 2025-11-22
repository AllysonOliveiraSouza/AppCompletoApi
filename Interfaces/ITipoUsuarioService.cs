using AppCompletoApi.Dtos;
using AppCompletoApi.Models;

namespace AppCompletoApi.Interfaces
{
    public interface ITipoUsuarioService
    {
        public TipoUsuario? Criar(TipoUsuarioDto dto);
        public TipoUsuarioDto Alterar(TipoUsuarioDto dto);
        public RespostaDto Excluir(int id);
        public List<TipoUsuarioDto> Listar();
        public TipoUsuarioDto Obter(int id);
    }
}
