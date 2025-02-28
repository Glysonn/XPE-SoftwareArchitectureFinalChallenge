namespace ProdManager.Application.DTOs;

public sealed record CreateProductDto(string Code, string Name, decimal Price, string Description);