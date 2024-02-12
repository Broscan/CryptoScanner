namespace CryptoScanner.Data.Models
{
    public class CryptoModel
    {
        public int Id { get; set; }
        public string ApiId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
    }
}
