using Catalog.API.Data.Contracts;
using Catalog.API.Entities;
using Catalog.API.Settings;
using MongoDB.Driver;
using System;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(ICatalogDbSettings catalogDbSettings)
        {
            var client = new MongoClient(catalogDbSettings.ConnectionString);
            var database = client.GetDatabase(catalogDbSettings.DatabaseName);

            this.Products = database.GetCollection<Product>(catalogDbSettings.CollectionName);
            SeedCatalogContext.SeedData(this.Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}