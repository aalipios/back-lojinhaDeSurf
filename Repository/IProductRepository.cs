using back.models;

namespace back.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Products>> BuscaProdutos();
        Task<Products> BuscaProdutos(int id);
        void AdicionaProduto(Products produto);
        void AtualizaProduto(Products produto);
        void DeletaProduto(Products produto);        

        Task<bool> SaveChangesAsync();
    }
}