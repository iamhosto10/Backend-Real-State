using Million.RealEstate.Domain;

namespace Million.RealEstate.Application;

public interface IOwnerRepository
{
    Task<Owner> AddAsync(Owner owner, CancellationToken ct = default);
    Task<Owner?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<List<Owner>> GetAllAsync(CancellationToken ct = default);
    Task UpdateAsync(Owner owner, CancellationToken ct = default);
    Task DeleteAsync(string id, CancellationToken ct = default);
}
