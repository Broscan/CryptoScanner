using CryptoScanner.App.ApiModels;
using CryptoScanner.App.Services;
using CryptoScanner.Data;
using CryptoScanner.Data.Models;
using Newtonsoft.Json;

namespace CryptoScanner.App
{
	public class ApiCaller
	{
		internal HttpClient Client { get; set; }
		private readonly CryptoRepo repo;
		private readonly AppDbContext context;
		public ApiCaller(AppDbContext context)
		{
			this.context = context;
			repo = new CryptoRepo(context);
			Client = new HttpClient();
			Client.BaseAddress = new Uri("https://api.coingecko.com/api/v3/");
		}



		public async Task<CryptoModel> MakeCall(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentNullException("name");
			}

			var dbTry = repo.GetCurrencyByName(name);
			if (dbTry != null)
			{
				return dbTry;
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
				if (searchedObject != null && searchedObject.Id != null)
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
			CryptoModel model = new CryptoModel()
			{
				Name = result.Name,
				ApiId = result.Id,
				Price = result.MarketData.CurrentPrice.Sek
			};

			return model;


		}

		public async Task<List<CryptoModel>> RefreshStoredCoins()
		{
			List<CryptoModel> coinsToRefresh = new();
			coinsToRefresh = new CoinsManager(context).GetDesc();
			foreach (var coin in coinsToRefresh)
			{
				var updatedCoin = await GetById(coin.ApiId);
			}
			return coinsToRefresh; // Inte min
		}


	}
}
