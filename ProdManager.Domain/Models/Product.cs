namespace ProdManager.Domain.Models;

public sealed class Product
{
    public Guid Id { get; init; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }
    
    private Product(
        Guid id,
        string name,
        decimal price,
        string description)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
    }

    public static Product Create(string name, decimal price, string description)
    {
        var product = new Product(Guid.NewGuid(), name, price, description);
        return product;
    }
}