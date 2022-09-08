namespace Backroom.Functions.Objects.Models;

public class ObjectPayload
{
    // public int ObjectId { get; set; }
    // public Dictionary<string, string> Object { get; set; } = new Dictionary<string, string>();
}

public class SetObjectPropertyValuePayload : ObjectPayload
{
    public string Value { get; set; } = string.Empty;
}

public class GetObjectPropertyPayload : ObjectPayload
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}