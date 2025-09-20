using MongoDB.Driver;
using Million.RealEstate.Domain;
using Million.RealEstate.Application;
using Microsoft.Extensions.Options;

namespace Million.RealEstate.Infrastructure;

public class PropertyTraceRepository : IPropertyTraceRepository
{
    private readonly IMongoCollection<PropertyTrace> _col;

    public PropertyTraceRepository(IMongoClient client, IOptions<MongoSettings> opts)
    {
        var db = client.GetDatabase(opts.Value.DatabaseName);
        _col = db.GetCollection<PropertyTrace>(opts.Value.PropertyTracesCollectionName);
    }

    public async Task<PropertyTrace> AddAsync(PropertyTrace trace, CancellationToken ct = default)
    {
        await _col.InsertOneAsync(trace, cancellationToken: ct);
        return trace;
    }

    public async Task<PropertyTrace?> GetByIdAsync(string id, CancellationToken ct = default) =>
        await _col.Find(x => x.IdPropertyTrace == id).FirstOrDefaultAsync(ct);

    public async Task<List<PropertyTrace>> GetByPropertyAsync(string propertyId, CancellationToken ct = default) =>
        await _col.Find(x => x.IdProperty == propertyId).ToListAsync(ct);

    public async Task UpdateAsync(PropertyTrace trace, CancellationToken ct = default) =>
        await _col.ReplaceOneAsync(x => x.IdPropertyTrace == trace.IdPropertyTrace, trace, cancellationToken: ct);

    public async Task DeleteAsync(string id, CancellationToken ct = default) =>
        await _col.DeleteOneAsync(x => x.IdPropertyTrace == id, ct);
}
