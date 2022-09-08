namespace Backroom.Functions.Arrays.Models;

public class ArrayRangePayload : ArrayPayload
{
    public List<string> Range { get; set; } = new();
}