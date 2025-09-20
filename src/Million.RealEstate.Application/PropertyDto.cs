namespace Million.RealEstate.Application;

public record PropertyDto(
    string? Id,
    string IdOwner,
    string Name,
    string Address,
    decimal Price,
    string Image
);
