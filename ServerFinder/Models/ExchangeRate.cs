using Newtonsoft.Json;

namespace ServerFinder.Models;

public class ExchangeRate
{
    
    [JsonProperty("success")]
    public bool Success { get; set; }

    [JsonProperty("timestamp")]
    public int Timestamp { get; set; }

    [JsonProperty("base")]
    public string Base { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }

    [JsonProperty("rates")]
    public Dictionary<string, float> Rates { get; set; }
}