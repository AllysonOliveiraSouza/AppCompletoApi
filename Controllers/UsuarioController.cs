using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppCompletoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;
        private readonly ILoginService _loginService;
        public UsuarioController(IUsuarioService service, ILoginService loginService)
        {
            _service = service;
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public ActionResult<string?> Login(LoginDto dto)
        {
            bool validacao = _loginService.ValidaLogin(dto);
            return (!validacao)? BadRequest("Credenciais inválidas !"): _loginService.GetJwt(dto);
        }

        [HttpPost]
        public ActionResult<Usuario> Post(UsuarioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var resp = _service.Criar(dto);
            return (resp==null) ? BadRequest("Erro ao criar usuário !") : resp;
        }

        [HttpGet]
        public ActionResult<List<UsuarioDto>> Get()
        {
            return _service.Listar();
        }
    }
}
