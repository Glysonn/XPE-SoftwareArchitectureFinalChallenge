using ProdManager.Domain.Models;

namespace ProdManager.Domain.Interfaces;

public interface IProductRepository
{
    void CreateProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    
    int CountProducts();
    Product? FindProductById(Guid id);
    Product? FindProductByCode(string code);
    IEnumerable<Product> FindProductsByName(string name);
    IEnumerable<Product> FindAllProducts();    
}