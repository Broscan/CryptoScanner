using CryptoScanner.App.ApiModels;
using CryptoScanner.Data;
using CryptoScanner.Data.Models;
using Newtonsoft.Json;

namespace CryptoScanner.App
{
    public class ApiCaller
    {
        internal HttpClient Client { get; set; }
        private readonly AppDbContext context;
        public ApiCaller(AppDbContext context)
        {
            this.context = context;
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
        }

        public async Task<CryptoModel> MakeCall(string name)
        {

            CryptoRepo repo = new(context);

            CryptoModel dbResponse = repo.GetProductByName(name);

            if (dbResponse != null)
            {
                return dbResponse;
            }

            HttpResponseMessage response = await Client.GetAsync("coins/list");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            string json = await response.Content.ReadAsStringAsync();
            //Trace.WriteLine(json);


            var result = JsonConvert.DeserializeObject<List<CoinListRoot>>(json);
            if (result != null)
            {
                CoinListRoot? searchedObject = result.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
                if (searchedObject != null)
                {
                    return await GetById(searchedObject.Id);
                }
            }


            throw new Exception("There was some problems getting that currency");



        }

        private async Task<CryptoModel> GetById(string id)
        {
            HttpResponseMessage response = await Client.GetAsync($"coins/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }

            string json = await response.Content.ReadAsStringAsync();

            if (json == null)
            {
                throw new HttpRequestException();
            }

            var result = JsonConvert.DeserializeObject<CoinRoot>(json);

            if (result == null)
            {
                throw new JsonSerializationException();
            }

            return new CryptoModel()
            {
                Name = result.Name,
                ApiId = result.Id,
                Price = result.MarketData.CurrentPrice.Sek
            };


        }


    }
}
