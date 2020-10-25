using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(string id);

        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);

        Task<IEnumerable<Product>> GetProductByCategoryAsync(string category);

        Task<Product> Create(Product product);

        Task<bool> Update(Product product);

        Task<bool> Delete(string productId);
    }
}
