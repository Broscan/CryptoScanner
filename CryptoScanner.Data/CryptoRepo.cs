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


        public IEnumerable<CryptoModel> AddCurrency(CryptoModel currency)
        {
            context.Currency.Add(currency);

            context.SaveChanges();

            return GetCurrency();
        }

        public CryptoModel GetCurrencyById(int id)
        {
            return context.Currency.FirstOrDefault(p => p.Id == id)!;
        }
        public CryptoModel GetCurrencyByName(string name)
        {
            return context.Currency.FirstOrDefault(p => p.Name == name)!;
        }

        public IEnumerable<CryptoModel> GetCurrency()
        {
            return context.Currency.ToList();
        }

        public void RemoveById(int id)
        {
            CryptoModel currencyToRemove = GetCurrencyById(id);

            context.Currency.Remove(currencyToRemove);

        }

        public async Task Update(CryptoModel currency)
        {
            // Hämta med id som oliver skickar med
            CryptoModel updatedCurrency = GetCurrencyById(currency.Id);

            // Cryptomodel.price = det oliver skickar med
            updatedCurrency.Price = currency.Price;

            await context.SaveChangesAsync();
        }


        // Helper function för att sortera currencies
        //public IEnumerable<CryptoModel> SortCurrency(string sortSpecificCurrency)
        //{
        //    if (sortSpecificCurrency == "asc")
        //    {
        //        return context.Currency.ToList().OrderBy(name => name.Name);
        //    }
        //    return context.Currency.ToList().OrderByDescending(name => name.Name);
        //}


    }
}
