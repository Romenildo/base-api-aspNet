using base_api_aspNet.Models;
using base_api_aspNet.Models.Dtos;
using base_api_aspNet.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace base_api_aspNet.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IBaseRepository _baseRepository;

        public BaseController(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<BaseDto>>> BuscarTodosLivros()
        {
            List<BaseDto> resultado = await _baseRepository.BuscarTodos();
            return resultado.Any() ? Ok(resultado) : BadRequest("não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDto>> BuscarPorID(Guid id)
        {
            BaseDto resultado = await _baseRepository.BuscarPorID(id);
            return resultado == null ? BadRequest() : Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<BaseDto>> Cadastrar([FromBody] Base nbase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            BaseDto resultado = await _baseRepository.Adicionar(nbase);
            return Created($"v1/api/Livro/{resultado.Id}", resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseDto>> Atualizar(Guid id, [FromBody] Base ubase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            ubase.Id = id;
            BaseDto resultado = await _baseRepository.Atualizar(id, ubase);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Boolean>> Deletar(Guid id)
        {
            Boolean resultado = await _baseRepository.Deletar(id);
            return Ok(resultado);
        }
    }
}
