using CryptoScanner.App.Services;
using CryptoScanner.Data;
using CryptoScanner.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoScanner.UI.Pages;

public class YourWalletModel : PageModel
{
	private readonly AppDbContext _dbContext;
	public List<CryptoModel> Currencies { get; set; } = new List<CryptoModel>();

	public YourWalletModel(AppDbContext dbContext)
	{
		_dbContext = dbContext;
		Currencies = new List<CryptoModel>();
	}

	public async Task OnGet()
	{
		//Displaya
		await DisplayCurrency();
	}
	public async Task OnPost(string sortOrder)
	{
		// sortera med if med Coinsmanager
		var coinsManager = new CoinsManager(_dbContext);
		if (sortOrder.ToLower() == "desc")
		{
			Currencies = coinsManager.GetDesc();
		}
		else
		{
			Currencies = coinsManager.GetAsc();
		}
	}

	public async Task DisplayCurrency()
	{
		Currencies.Clear();


		foreach (var currency in _dbContext.Currency)
		{
			CryptoModel cryptoAdd = new CryptoModel()
			{
				Name = currency.Name,
				ApiId = currency.ApiId,
				Price = currency.Price,
			};
			Currencies.Add(cryptoAdd);
		}

	}
}
