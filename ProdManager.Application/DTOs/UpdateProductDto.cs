namespace ProdManager.Application.DTOs;

public sealed record UpdateProductDto(Guid Id, string Name, decimal Price, string Description);