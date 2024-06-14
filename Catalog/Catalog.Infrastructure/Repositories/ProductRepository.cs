using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
{
    private readonly ICatalogContext _context;
    public ProductRepository(ICatalogContext context)
    {
        _context = context;
    }

    public Task<Product> CreateProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteProduct(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductType>> GetAllTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _context
            .Products
            .Find(_=> _.Id == id)
            .FirstOrDefaultAsync();
    }

    public Task<Product> GetProductByBrand(string brand)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context
            .Products
            .Find(_ => true)
            .ToListAsync();
    }

    public Task<bool> UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}
