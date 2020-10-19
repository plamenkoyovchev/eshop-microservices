using Catalog.API.Data.Contracts;
using Catalog.API.Entities;
using Catalog.API.Settings;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly CatalogDbSettings catalogDbSettings;

        public CatalogContext(ICatalogDbSettings catalogDbSettings)
        {
            var client = new MongoClient(catalogDbSettings.ConnectionString);
            var database = client.GetDatabase(catalogDbSettings.DatabaseName);

            this.Products = database.GetCollection<Product>(catalogDbSettings.CollectionName);
        }

        public IMongoCollection<Product> Products { get; }
    }
}