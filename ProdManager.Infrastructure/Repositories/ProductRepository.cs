using ProdManager.Domain.Interfaces;
using ProdManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ProdManager.Infrastructure.Repositories;

public sealed class ProductRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    public void CreateProduct(Product product)
    {
        _context.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        _context.Update(product);
    }

    public void DeleteProduct(Product product)
    {
        _context.Remove(product);
    }

    public int CountProducts()
    {
        return _context.Products.Count();
    }

    public Product? FindProductById(Guid id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Product> FindAllProducts()
    {
        return _context.Products.ToList();
    }

    public IEnumerable<Product> FindProductByName(string name)
    {
        return _context.Products.Where(x => EF.Functions.Like(x.Name, $"%{name}%"));
    }
}