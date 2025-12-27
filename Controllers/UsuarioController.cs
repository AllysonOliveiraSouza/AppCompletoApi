using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppCompletoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ILoginService _loginService;
        private readonly ISenhaService _senhaService;


        public UsuarioController(IUsuarioService service, ILoginService loginService, ISenhaService senhaService)
        {
            _service = service;
            _loginService = loginService;
            _senhaService=senhaService;
        }

        [HttpPost("Login")]
        public ActionResult<string?> Login(LoginDto dto)
        {
            bool validacao = _loginService.ValidaLogin(dto);
            return (!validacao)? BadRequest("Credenciais inválidas !"): _loginService.GetJwt(dto);
        }

        [HttpPost]
        public ActionResult<Usuario> Post(CadastroDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();            
            var usuarioCadastrado = _service.Criar(new() { Email = dto.Email, Nome = dto.Nome, Sexo = dto.Sexo});

            if (usuarioCadastrado!=null) {
                var senha = _senhaService.Criar(new() { Senha=dto.Senha, UsuarioId = usuarioCadastrado.Id });
                if (senha==null) {
                    _service.Excluir(usuarioCadastrado.Id);
                    return BadRequest("Erro ao criar usuário !");
                }
            } else return BadRequest("Erro ao criar usuário");

            return usuarioCadastrado;
        }

        [HttpGet]
        [Authorize(Roles = "Adm")]
        public ActionResult<List<UsuarioDto>> Get()
        {
            return _service.Listar();
        }

        [HttpGet("Autenticado")]
        [Authorize]
        public ActionResult<UsuarioDto?> GetLogado()
        {
            var idUsuario = User.FindFirst("Id")?.Value;
            
            if (idUsuario == null) return BadRequest();
            var usuario = _service.Obter(int.Parse(idUsuario));

            return usuario==null?BadRequest():usuario;
        }
    }
}
