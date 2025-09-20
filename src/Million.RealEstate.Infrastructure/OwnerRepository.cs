using MongoDB.Driver;
using Million.RealEstate.Domain;
using Million.RealEstate.Application;
using Microsoft.Extensions.Options;

namespace Million.RealEstate.Infrastructure;

public class OwnerRepository : IOwnerRepository
{
    private readonly IMongoCollection<Owner> _col;

    public OwnerRepository(IMongoClient client, IOptions<MongoSettings> opts)
    {
        var db = client.GetDatabase(opts.Value.DatabaseName);
        _col = db.GetCollection<Owner>(opts.Value.OwnersCollectionName);
    }

    public async Task<Owner> AddAsync(Owner owner, CancellationToken ct = default)
    {
        await _col.InsertOneAsync(owner, cancellationToken: ct);
        return owner;
    }

    public async Task<Owner?> GetByIdAsync(string id, CancellationToken ct = default) =>
        await _col.Find(x => x.IdOwner == id).FirstOrDefaultAsync(ct);

    public async Task<List<Owner>> GetAllAsync(CancellationToken ct = default) =>
        await _col.Find(Builders<Owner>.Filter.Empty).ToListAsync(ct);

    public async Task UpdateAsync(Owner owner, CancellationToken ct = default) =>
        await _col.ReplaceOneAsync(x => x.IdOwner == owner.IdOwner, owner, cancellationToken: ct);

    public async Task DeleteAsync(string id, CancellationToken ct = default) =>
        await _col.DeleteOneAsync(x => x.IdOwner == id, ct);
}
