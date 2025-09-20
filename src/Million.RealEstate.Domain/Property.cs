using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Million.RealEstate.Domain;

public class Owner
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdOwner { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Photo { get; set; } = string.Empty;
    public DateTime Birthday { get; set; }
}

public class Property
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdProperty { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string CodeInternal { get; set; } = string.Empty;
    public int Year { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string IdOwner { get; set; } = string.Empty;
}

public class PropertyImage
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdPropertyImage { get; set; } = string.Empty;

    [BsonRepresentation(BsonType.ObjectId)]
    public string IdProperty { get; set; } = string.Empty;

    public string File { get; set; } = string.Empty;
    public bool Enabled { get; set; }
}

public class PropertyTrace
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string IdPropertyTrace { get; set; } = string.Empty;

    public DateTime DateSale { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public decimal Tax { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string IdProperty { get; set; } = string.Empty;
}
