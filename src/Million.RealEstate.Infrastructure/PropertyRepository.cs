using MongoDB.Driver;
using Million.RealEstate.Domain;
using Million.RealEstate.Application;
using Microsoft.Extensions.Options;

namespace Million.RealEstate.Infrastructure;

public class PropertyRepository : IPropertyRepository
{
    private readonly IMongoCollection<Property> _col;

    public PropertyRepository(IMongoClient client, IOptions<MongoSettings> opts)
    {
        var db = client.GetDatabase(opts.Value.DatabaseName);
        _col = db.GetCollection<Property>(opts.Value.PropertiesCollectionName);
    }

    public async Task<Property> AddAsync(Property property, CancellationToken ct = default)
    {
        await _col.InsertOneAsync(property, cancellationToken: ct);
        return property;
    }

    public async Task<Property?> GetByIdAsync(string id, CancellationToken ct = default) =>
        await _col.Find(x => x.IdProperty == id).FirstOrDefaultAsync(ct);
    public async Task<Property?> GetByNameAsync(string name, CancellationToken ct = default) =>
        await _col.Find(x => x.Name == name).FirstOrDefaultAsync(ct);
    public async Task<Property?> GetByAddressAsync(string address, CancellationToken ct = default) =>
        await _col.Find(x => x.Address == address).FirstOrDefaultAsync(ct);
    public async Task<List<Property>> GetByPriceRangeAsync(decimal minPrice, decimal maxPrice, CancellationToken ct = default)
    {
        int min = (int)Math.Floor(minPrice);
        int max = (int)Math.Ceiling(maxPrice);
        var filter = Builders<Property>.Filter.Where(p => p.Price >= min && p.Price <= max);

        return await _col.Find(filter).ToListAsync(ct);
    }
    public async Task<List<Property>> GetAllAsync(CancellationToken ct = default) =>
        await _col.Find(Builders<Property>.Filter.Empty).ToListAsync(ct);

    public async Task UpdateAsync(Property property, CancellationToken ct = default) =>
        await _col.ReplaceOneAsync(x => x.IdProperty == property.IdProperty, property, cancellationToken: ct);

    public async Task DeleteAsync(string id, CancellationToken ct = default) =>
        await _col.DeleteOneAsync(x => x.IdProperty == id, ct);
    public async Task<List<Property>> GetByOwnerAsync(string ownerId, CancellationToken ct = default) =>
        await _col.Find(x => x.IdOwner == ownerId).ToListAsync(ct);
}
