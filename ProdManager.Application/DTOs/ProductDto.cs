namespace ProdManager.Application.DTOs;

public sealed record ProductDto(Guid Id, string Name, decimal Price, string Description);