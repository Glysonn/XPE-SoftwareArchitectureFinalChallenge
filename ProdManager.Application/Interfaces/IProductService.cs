using ProdManager.Application.DTOs;

namespace ProdManager.Application.Interfaces;

public interface IProductService
{
    void CreateProduct(CreateProductDto dto);
    void UpdateProduct(UpdateProductDto dto);
    void DeleteProduct(Guid id);

    int CountProducts();
    ProductDto? FindProductById(Guid id);
    IEnumerable<ProductDto> FindAllProducts();
    IEnumerable<ProductDto> FindProductsByName(string name);
}