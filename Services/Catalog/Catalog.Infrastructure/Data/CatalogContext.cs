using Catalog.Domain.Entities;
using Catalog.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public sealed class CatalogContext
{
    public CatalogContext(IMongoDatabase database, IOptions<MongoDbSettings> settings)
    {
        Products = database.GetCollection<Product>(settings.Value.ProductsCollectionName);
    }

    public IMongoCollection<Product> Products { get; }
}
