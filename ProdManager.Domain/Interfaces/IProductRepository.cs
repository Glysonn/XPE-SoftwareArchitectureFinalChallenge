using ProdManager.Domain.Models;

namespace ProdManager.Domain.Interfaces;

public interface IProductRepository
{
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    
    int CountProducts();
    Product? FindProductById(Guid id);
    IEnumerable<Product> FindAllProducts();    
    IEnumerable<Product> FindProductByName(string name);
}