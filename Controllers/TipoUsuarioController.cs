using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppCompletoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioService _service;
        public TipoUsuarioController(ITipoUsuarioService service) {
            _service = service;
        }

        [HttpPost]
        public ActionResult<TipoUsuario> Post(TipoUsuarioDto dto)
        {
            var resp = _service.Criar(dto);            
            return (resp!=null)?resp:BadRequest("Erro ao inserir tipo de usuário !");
        }

        [Authorize]
        [HttpGet]
        public ActionResult<List<TipoUsuarioDto>> Get() {
            return _service.Listar();
        }
    }
}
