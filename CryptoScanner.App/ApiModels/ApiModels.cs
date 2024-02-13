using Newtonsoft.Json;

namespace CryptoScanner.App.ApiModels
{

    public class CoinListRoot
    {

        [JsonProperty("id")]
        public string? Id { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }

    }
    public class CoinRoot
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        [JsonProperty("market_data")]
        public MarketData? MarketData { get; set; }
    }

    public class MarketData
    {
        [JsonProperty("current_price")]
        public CurrentPrice? CurrentPrice { get; set; }
    }

    public class CurrentPrice
    {
        [JsonProperty("sek")]
        public decimal? Sek { get; set; }
    }
}