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

        public async Task<Product> Create(Product product)
        {
            await this.catalog.Products.InsertOneAsync(product);
            return product;
        }

        public async Task<bool> Delete(string productId)
        {
            var result = await this.catalog.Products.DeleteOneAsync(p => p.Id == productId);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetProductByCategoryAsync(string category)
        {
            return await this.catalog.Products.Find(p => p.Category == category).ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await this.catalog.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await this.catalog.Products.Find(p => p.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this.catalog.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Product product)
        {
            var result = await this.catalog.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
