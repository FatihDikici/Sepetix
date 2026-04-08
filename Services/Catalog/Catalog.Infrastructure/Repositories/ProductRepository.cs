using Catalog.Domain.Entities;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public sealed class ProductRepository(CatalogContext context) : IProductRepository
{
    public async Task<IReadOnlyCollection<Product>> GetAll(CancellationToken cancellationToken = default)
    {
        return await context.Products
            .Find(_ => true)
            .ToListAsync(cancellationToken);
    }

    public async Task Create(Product product, CancellationToken cancellationToken = default)
    {
        await context.Products.InsertOneAsync(product, cancellationToken: cancellationToken);
    }
}
