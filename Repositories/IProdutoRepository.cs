using ProdutoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdutoAPI.Repositories
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetAllAsync();
        Task<Produto> GetByIdAsync(int id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
    }
}
