using AppCompletoApi.Context;
using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;
using AppCompletoApi.Static;

namespace AppCompletoApi.Services
{
    public class SenhaService : ISenhaService
    {
        private readonly AppDbContext _context;
        public SenhaService(AppDbContext context) {
            _context = context;
        }

        public SenhaDto Alterar(SenhaDto dto)
        {
            throw new NotImplementedException();
        }

        public Senha? Criar(SenhaDto dto)
        {
            string senhaCriptografada = Cript.CriaHashSenha(dto.SenhaHash);
            var usuario = _context.Usuario.FirstOrDefault(u => u.Id==dto.UsuarioId);

            if (usuario==null) return null;
            
            Senha senha = new() { SenhaHash = senhaCriptografada, Usuario = usuario, UsuarioId = usuario.Id };

            _context.Add(senha);
            _context.SaveChanges();

            return senha;
        }

        public RespostaDto Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<SenhaDto> Listar()
        {
            throw new NotImplementedException();
        }

        public SenhaDto Obter(int id)
        {
            throw new NotImplementedException();
        }
    }
}
