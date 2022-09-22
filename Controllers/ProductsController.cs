using Microsoft.AspNetCore.Mvc;
using back.Repository;
using back.models;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository repository;

        public ProductsController(IProductRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await repository.BuscaProdutos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await repository.BuscaProdutos(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Products produto)
        {
            repository.AdicionaProduto(produto);
            return await repository.SaveChangesAsync()
            ? Ok("Produto adicionado com sucesso")
            : BadRequest("Erro ao salvar o produto");
        }

        [HttpPut]
        public async Task<IActionResult> Put(Products produto, int id)
        {
            var product = await repository.BuscaProdutos(id);
            if (produto == null) return NotFound("Produto não encontrado");
            product.name = produto.name ?? product.name;
            product.url = produto.url ?? product.url;
            repository.AtualizaProduto(produto);
            return Ok(await repository.SaveChangesAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var produto = await repository.BuscaProdutos(id);
            repository.DeletaProduto(produto);

            return await repository.SaveChangesAsync()
            ? Ok("Produto deletado")
            : BadRequest("Erro");
        }
    }
}