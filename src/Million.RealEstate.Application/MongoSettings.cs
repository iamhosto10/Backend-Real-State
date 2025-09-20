namespace Million.RealEstate.Application;

public class MongoSettings
{
    public string ConnectionString { get; set; } = "mongodb://localhost:27017";
    public string DatabaseName { get; set; } = "million_realestate";

    // Colecciones
    public string OwnersCollectionName { get; set; } = "owners";
    public string PropertiesCollectionName { get; set; } = "properties";
    public string PropertyImagesCollectionName { get; set; } = "property_images";
    public string PropertyTracesCollectionName { get; set; } = "property_traces";
}
