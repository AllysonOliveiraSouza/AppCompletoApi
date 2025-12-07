using AppCompletoApi.Context;
using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;

namespace AppCompletoApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AppDbContext _context;
        public UsuarioService(AppDbContext context) { 
            _context = context;
        }

        public UsuarioDto Alterar(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        public Usuario? Criar(UsuarioDto dto)
        {
            Usuario usuario = new() { Nome = dto.Nome, Email = dto.Email, Sexo = dto.Sexo};
            var tipoUsuario = _context.TipoUsuario.FirstOrDefault(t => t.Id==2);

            if (tipoUsuario == null) return null;

            usuario.TipoUsuario = tipoUsuario;
            usuario.TipoUsuarioId = tipoUsuario.Id;

            _context.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public RespostaDto Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioDto> Listar()
        {
            var lista = _context.Usuario.ToList();
            List<UsuarioDto> l = [];

            if (lista==null) return [];

            foreach (var usuario in lista)
            {
                l.Add(new() { Id = usuario.Id, Email = usuario.Email, Nome = usuario.Nome, Sexo = usuario.Sexo, TipoUsuarioId = usuario.TipoUsuarioId});
            }

            return l;
        }

        public UsuarioDto Obter(int id)
        {
            throw new NotImplementedException();
        }

        #region Private



        #endregion
    }
}
