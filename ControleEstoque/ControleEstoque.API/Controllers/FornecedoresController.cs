using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedorService _FornecedorService;

        public FornecedoresController(IFornecedorService fornecedorService)
        {
            _FornecedorService = fornecedorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
           var fornecedores = await _FornecedorService.ObterTodosAsync();
            return Ok(fornecedores);
        }
        [HttpGet("{id}")]//recebe  rota 
        public async Task<IActionResult> GetById(int id) 
        {
           var result = await _FornecedorService.ObterPorIdAsync(id);
            if (result == null) NotFound();
      
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CriarFornecedorDto dto)
        {
            FornecedorDto result = await _FornecedorService.CriarAsync(dto);
            return Created(nameof(Create), result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AtualizarFornecedorDto dto)
        {
            var existe = await _FornecedorService.ObterPorIdAsync(id);
            if (existe == null) return NotFound();

            await _FornecedorService.AtualizarAsync(dto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _FornecedorService.RemoverAsync(id);
            return NoContent();
        }
       

    }
  
}
