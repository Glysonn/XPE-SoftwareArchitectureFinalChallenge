using ProdManager.Application.DTOs;
using ProdManager.Application.Interfaces;
using ProdManager.Domain.Interfaces;
using ProdManager.Domain.Models;

namespace ProdManager.Application.Services
{
    public class ProductService(
        IProductRepository productRepository,
        IUnitOfWork unitOfWork)
        : IProductService
    {
        public void CreateProduct(CreateProductDto dto)
        {
            var product = Product.Create(dto.Code, dto.Name, dto.Price, dto.Description);
            productRepository.CreateProduct(product);

            unitOfWork.Commit();
        }

        public void UpdateProduct(UpdateProductDto dto)
        {
            var existing = productRepository.FindProductById(dto.Id);
            if (existing == null)
                throw new InvalidOperationException("Product not found");
            
            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.Description = dto.Description;

            productRepository.UpdateProduct(existing);
            unitOfWork.Commit();
        }

        public void DeleteProduct(Guid id)
        {
            var existing = productRepository.FindProductById(id);
            if (existing == null)
                throw new Exception("Product not found");

            productRepository.DeleteProduct(existing);
            unitOfWork.Commit();
        }

        public int CountProducts()
        {
            return productRepository.CountProducts();
        }

        public ProductDto? FindProductById(Guid id)
        {
            var product = productRepository.FindProductById(id);

            return product is null
                ? null
                : new ProductDto(product.Id, product.Code, product.Name, product.Price, product.Description);
        }
        
        public ProductDto? FindProductByCode(string code)
        {
            var product = productRepository.FindProductByCode(code);

            return product is null
                ? null
                : new ProductDto(product.Id, product.Code, product.Name, product.Price, product.Description);
        }

        public IEnumerable<ProductDto> FindAllProducts()
        {
            var products = productRepository.FindAllProducts();
            return products.Select(p => new ProductDto(
                p.Id,
                p.Code,
                p.Name,
                p.Price,
                p.Description
            ));
        }

        public IEnumerable<ProductDto> FindProductsByName(string name)
        {
            var products = productRepository.FindProductsByName(name);
            return products.Select(p => new ProductDto(
                p.Id,
                p.Code,
                p.Name,
                p.Price,
                p.Description
            ));
        }
    }
}