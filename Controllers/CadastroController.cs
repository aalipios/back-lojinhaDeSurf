using Microsoft.AspNetCore.Mvc;
using back.Repository;
using back.models;

namespace back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly IUsuarioRepository repository;

        public CadastroController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await repository.BuscaUsuario());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await repository.BuscaUsuario(id);
            return usuario != null
            ? Ok(usuario)
            : NotFound("Usuário não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cadastro usuario)
        {
            repository.AdicionaUsuario(usuario);
            return await repository.SaveChangesAsync()
            ? Ok("Usuário adicionado com sucesso")
            : BadRequest("Erro ao salvar o usuário");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var usuario = await repository.BuscaUsuario(id);
            repository.DeletaUsuario(usuario);
            
            return await repository.SaveChangesAsync()
            ? Ok("Usuário deletado")
            : BadRequest("Erro");
        }
        
    }
}