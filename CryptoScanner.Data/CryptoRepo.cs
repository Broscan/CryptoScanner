using CryptoScanner.Data.Models;

namespace CryptoScanner.Data
{
    public class CryptoRepo
    {
        private readonly AppDbContext context;

        public CryptoRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<CryptoModel> AddProduct(CryptoModel currency)
        {
            context.Currency.Add(currency);

            context.SaveChanges();

            return GetCurrency();
        }

        public CryptoModel GetProductById(int id)
        {
            return context.Currency.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<CryptoModel> GetCurrency()
        {
            return context.Currency.ToList();
        }

    }
}
