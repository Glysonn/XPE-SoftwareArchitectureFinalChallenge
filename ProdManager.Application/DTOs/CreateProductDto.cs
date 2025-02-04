namespace ProdManager.Application.DTOs;

public sealed record CreateProductDto(string Name, decimal Price, string Description);