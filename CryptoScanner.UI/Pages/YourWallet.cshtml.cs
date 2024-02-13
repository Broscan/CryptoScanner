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
	}

	public void OnGet()
	{
		DisplayCurrency();


	}

	public async Task DisplayCurrency()
	{
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
