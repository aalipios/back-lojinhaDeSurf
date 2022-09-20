using Microsoft.EntityFrameworkCore;
using back.models;

namespace back.db
{
    public class UsuarioContext :DbContext
    {
        public UsuarioContext(DbContextOptions <UsuarioContext> options) : base(options)
        {
        }
        public DbSet<Cadastro> Usuarios {get; set;}
    }
}