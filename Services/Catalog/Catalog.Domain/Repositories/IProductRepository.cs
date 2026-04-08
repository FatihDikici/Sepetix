using Catalog.Domain.Entities;

namespace Catalog.Domain.Repositories;

public interface IProductRepository
{
    Task<IReadOnlyCollection<Product>> GetAll(CancellationToken cancellationToken = default);
    Task Create(Product product, CancellationToken cancellationToken = default);
}
