using AppCompletoApi.Dtos;
using AppCompletoApi.Interfaces;
using AppCompletoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppCompletoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SenhaController : ControllerBase
    {
        private readonly ISenhaService _service;
        public SenhaController(ISenhaService service) { 
            _service = service;
        }    

        [HttpPost]
        public ActionResult<Senha> Post(SenhaDto dto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var resp = _service.Criar(dto);
            return resp==null? BadRequest("Erro ao cadastrar senha"):resp;
        }
    }
}
