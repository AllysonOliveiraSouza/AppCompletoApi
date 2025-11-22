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
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Usuario> Post(UsuarioDto dto)
        {
            var resp = _service.Criar(dto);
            return (resp==null)?BadRequest("Erro ao criar usuário !"):resp;
        }

        [HttpGet]
        public ActionResult<List<UsuarioDto>> Get()
        {
            return _service.Listar();
        }
    }
}
