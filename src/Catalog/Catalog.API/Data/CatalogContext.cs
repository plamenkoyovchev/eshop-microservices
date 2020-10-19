using Catalog.API.Data.Contracts;
using Catalog.API.Entities;
using Catalog.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly CatalogDbSettings catalogDbSettings;

        public CatalogContext(IOptions<CatalogDbSettings> catalogDbSettings)
        {
            this.catalogDbSettings = catalogDbSettings.Value;
            var client = new MongoClient(this.catalogDbSettings.ConnectionString);
            var database = client.GetDatabase(this.catalogDbSettings.DatabaseName);

            this.Products = database.GetCollection<Product>(this.catalogDbSettings.CollectionName);
        }

        public IMongoCollection<Product> Products { get; }
    }
}