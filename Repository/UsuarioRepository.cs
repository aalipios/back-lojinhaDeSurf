using back.models;
using back.db;
using Microsoft.EntityFrameworkCore;

namespace back.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext context;

        public UsuarioRepository(UsuarioContext context)
        {
            this.context = context;
        }
        public void AdicionaUsuario(Cadastro usuario)
        {
            context.Add(usuario);
        }

        public void AtualizaUsuario(Cadastro usuario)
        {
            context.Update(usuario);
        }

        public async Task<Cadastro> BuscaUsuario(int id)
        {
            return await context.Usuarios.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cadastro>> BuscaUsuario()
        {
            return await context.Usuarios.ToListAsync();
        }

        public void DeletaUsuario(Cadastro usuario)
        {
            context.Remove(usuario);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}