using back.models;
namespace back.Repository
{
    public interface IUsuarioRepository
    {
         Task<IEnumerable<Cadastro>> BuscaUsuario();
        Task<Cadastro> BuscaUsuario(int id);
        void AdicionaUsuario(Cadastro usuario);
        void AtualizaUsuario(Cadastro usuario);
        void DeletaUsuario(Cadastro usuario);

        Task<bool> SaveChangesAsync();
    }
}