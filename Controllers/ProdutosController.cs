using Microsoft.AspNetCore.Mvc;
using ProdutoAPI.Models;
using ProdutoAPI.Repositories;

namespace ProdutoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
    {
        return Ok(await _produtoRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetProduto(int id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProduto(Produto produto)
    {
        await _produtoRepository.AddAsync(produto);
        return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduto(int id, Produto produto)
    {
        if (id != produto.Id)
        {
            return BadRequest();
        }
        await _produtoRepository.UpdateAsync(produto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduto(int id)
    {
        await _produtoRepository.DeleteAsync(id);
        return NoContent();
    }
}
