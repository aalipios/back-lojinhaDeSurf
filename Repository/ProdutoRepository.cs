using back.models;
using back.db;
using Microsoft.EntityFrameworkCore;

namespace back.Repository
{
    public class ProdutoRepository : IProductRepository
    {
        private readonly ProductContext context;

        public ProdutoRepository(ProductContext context)
        {
            this.context = context;
        }
        public void AdicionaProduto(Products produto)
        {
            context.Add(produto);
        }

        public void AtualizaProduto(Products produto)
        {
            context.Update(produto);;
        }

        public async Task<IEnumerable<Products>> BuscaProdutos()
        {
            return await context.Produtos.ToListAsync();
        }

        public async Task<Products> BuscaProdutos(int id)
        {
            return await context.Produtos.Where(x => x.id == id).FirstOrDefaultAsync();
        }

        public void DeletaProduto(Products produto)
        {
            context.Remove(produto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }
    }
}