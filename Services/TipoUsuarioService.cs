using AppCompletoApi.Context;
using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;

namespace AppCompletoApi.Services
{
    public class TipoUsuarioService : ITipoUsuarioService
    {
        private readonly AppDbContext _context;
        public TipoUsuarioService(AppDbContext context)
        {
            _context = context;
        }
        public TipoUsuarioDto Alterar(TipoUsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario? Criar(TipoUsuarioDto dto)
        {
            TipoUsuario tipoUsuario = new() { Titulo = dto.Titulo };
            _context.Add(tipoUsuario);
            _context.SaveChanges();

            return tipoUsuario; 
        }

        public RespostaDto Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<TipoUsuarioDto> Listar()
        {
            var lista = _context.TipoUsuario.ToList();
            List<TipoUsuarioDto> l = [];

            if (lista==null) return [];

            foreach(var t in lista)
            {
                l.Add(new() { Id = t.Id, Titulo = t.Titulo });
            }

            return l;
        }

        public TipoUsuarioDto Obter(int id)
        {
            throw new NotImplementedException();
        }
    }
}
