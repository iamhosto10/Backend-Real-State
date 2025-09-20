using Million.RealEstate.Domain;

namespace Million.RealEstate.Application;

public interface IPropertyTraceRepository
{
    Task<PropertyTrace> AddAsync(PropertyTrace trace, CancellationToken ct = default);
    Task<PropertyTrace?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<List<PropertyTrace>> GetByPropertyAsync(string propertyId, CancellationToken ct = default);
    Task UpdateAsync(PropertyTrace trace, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
}
