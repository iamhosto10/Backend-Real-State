using Million.RealEstate.Domain;

namespace Million.RealEstate.Application;

public interface IPropertyRepository
{
    Task<Property> AddAsync(Property property, CancellationToken ct = default);
    Task<Property?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<List<Property>> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(Property property, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
    Task<List<Property>> GetByOwnerAsync(string ownerId, CancellationToken ct = default);
}