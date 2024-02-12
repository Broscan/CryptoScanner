using System.ComponentModel.DataAnnotations;

namespace CryptoScanner.Data.Models
{
    public class CryptoModel
    {
        [Key]
        public int Id { get; set; }
        public string ApiId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public decimal? Price { get; set; }
    }
}
