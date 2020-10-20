using Catalog.API.Data.Contracts;
using Catalog.API.Entities;
using Catalog.API.Services.Contracts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Services
{
    public class ProductService : IProductService
    {
        private readonly ICatalogContext catalog;

        public ProductService(ICatalogContext catalog)
        {
            this.catalog = catalog;
        }

        public Task Create(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this.catalog.Products.Find(p => true).ToListAsync();
        }

        public Task<bool> Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
