using System;
namespace Catalog.Dtos
{
	public record ItemDto(Guid Id, string Name, string Desc, decimal Price, DateTimeOffset CreatedDate);
    public record CreateItemDto(string Name, string Desc, decimal Price);
    public record UpdareItemDto(string Name, string Desc, decimal Price);
}

