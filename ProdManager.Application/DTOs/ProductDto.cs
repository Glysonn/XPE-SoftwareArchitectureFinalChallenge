namespace ProdManager.Application.DTOs;

public sealed record ProductDto(Guid Id, string Code, string Name, decimal Price, string Description);