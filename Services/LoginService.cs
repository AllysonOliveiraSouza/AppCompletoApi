using AppCompletoApi.Context;
using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;
using AppCompletoApi.Static;
using Microsoft.EntityFrameworkCore;

namespace AppCompletoApi.Services
{
    public class LoginService : ILoginService
    {
        private readonly AppDbContext _context;
        public LoginService(AppDbContext context) {
            _context = context;
        }

        public string? GetJwt(LoginDto dto)
        {
            if (!ValidaLogin(dto)) return null;
            Usuario? usuario = _context.Usuario.Include(t=>t.TipoUsuario).AsNoTracking().FirstOrDefault(u => u.Email==dto.Email);       
            return JwtUtil.GerarToken(usuario!);
        }

        public bool ValidaLogin(LoginDto dto)
        {
            var usuario = _context.Usuario.AsNoTracking().FirstOrDefault(u=>u.Email==dto.Email);
            if (usuario == null) return false;
            var senha = _context.Senha.AsNoTracking().FirstOrDefault(s => s.UsuarioId==usuario.Id);
            if(senha == null) return false;

            return Cript.ValidaSenha(dto.Senha, senha.SenhaHash);
        }
    }
}
