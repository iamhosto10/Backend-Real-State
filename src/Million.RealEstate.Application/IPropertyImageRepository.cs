using Million.RealEstate.Domain;

namespace Million.RealEstate.Application;

public interface IPropertyImageRepository
{
    Task<List<PropertyImage>> GetAllAsync(CancellationToken ct = default);
    Task<PropertyImage> AddAsync(PropertyImage image, CancellationToken ct = default);
    Task<PropertyImage?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<List<PropertyImage>> GetByPropertyAsync(string propertyId, CancellationToken ct = default);
    Task UpdateAsync(PropertyImage image, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
}
