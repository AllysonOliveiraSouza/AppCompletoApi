using AppCompletoApi.Dtos;
using AppCompletoApi.Models;

namespace AppCompletoApi.Interfaces
{
    public interface ISenhaService
    {
        public Senha? Criar(SenhaDto dto);
        public SenhaDto Alterar(SenhaDto dto);
        public RespostaDto Excluir(int id);
        public List<SenhaDto> Listar();
        public SenhaDto Obter(int id);
    }
}
