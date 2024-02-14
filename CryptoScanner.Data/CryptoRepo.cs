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


        public async Task<IEnumerable<CryptoModel>> AddCurrency(CryptoModel currency)
        {
            if (GetCurrencyById(currency.Id) == null)
            {
                context.Currency.Add(currency);

                await context.SaveChangesAsync();

            }

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

        public void RemoveByName(string name)
        {
            CryptoModel currencyToRemove = GetCurrencyByName(name);

            context.Currency.Remove(currencyToRemove);

        }

        public async Task Update(CryptoModel currency)
        {
            // Hämta med id som oliver skickar med
            CryptoModel updatedCurrency = GetCurrencyByName(currency.Name);

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
