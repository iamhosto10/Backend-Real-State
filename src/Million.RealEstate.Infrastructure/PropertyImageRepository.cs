using MongoDB.Driver;
using Million.RealEstate.Domain;
using Million.RealEstate.Application;
using Microsoft.Extensions.Options;

namespace Million.RealEstate.Infrastructure;

public class PropertyImageRepository : IPropertyImageRepository
{
    private readonly IMongoCollection<PropertyImage> _col;

    public PropertyImageRepository(IMongoClient client, IOptions<MongoSettings> opts)
    {
        var db = client.GetDatabase(opts.Value.DatabaseName);
        _col = db.GetCollection<PropertyImage>(opts.Value.PropertyImagesCollectionName);
    }

    public async Task<PropertyImage> AddAsync(PropertyImage image, CancellationToken ct = default)
    {
        await _col.InsertOneAsync(image, cancellationToken: ct);
        return image;
    }

    public async Task<PropertyImage?> GetByIdAsync(string id, CancellationToken ct = default) =>
        await _col.Find(x => x.IdPropertyImage == id).FirstOrDefaultAsync(ct);
    public async Task<List<PropertyImage>> GetAllAsync(CancellationToken ct = default) =>
        await _col.Find(Builders<PropertyImage>.Filter.Empty).ToListAsync(ct);
    public async Task<List<PropertyImage>> GetByPropertyAsync(string propertyId, CancellationToken ct = default) =>
        await _col.Find(x => x.IdProperty == propertyId).ToListAsync(ct);

    public async Task UpdateAsync(PropertyImage image, CancellationToken ct = default) =>
        await _col.ReplaceOneAsync(x => x.IdPropertyImage == image.IdPropertyImage, image, cancellationToken: ct);

    public async Task DeleteAsync(string id, CancellationToken ct = default) =>
        await _col.DeleteOneAsync(x => x.IdPropertyImage == id, ct);
}
