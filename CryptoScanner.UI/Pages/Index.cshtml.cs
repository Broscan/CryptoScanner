using CryptoScanner.App;
using CryptoScanner.Data;
using CryptoScanner.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CryptoScanner.UI.Pages;

public class IndexModel : PageModel
{

	public string? ErrorMessage { get; set; }

	public CryptoModel? Currency { get; set; }
	[BindProperty]
	public string? CurrencyName { get; set; }

	public List<CryptoModel> ExampelCurrencies { get; set; }

	private readonly AppDbContext context;

	public IndexModel(AppDbContext dbContext)
	{
		context = dbContext;
		ExampelCurrencies = new List<CryptoModel>();
	}


	public async Task OnGetAsync() // Skicka till databasen o spara. Displaya sen i "Your wallet"
	{
		ExampelCurrencies = await context.Currency.Where(c => c.Id >= 1 && c.Id <= 7).ToListAsync(); // tog bort tidigare ids
	}
	public async Task<IActionResult> OnPost() // Sök på crypto valutor - skapa en lista av exempel namn sen
	{
		if (CurrencyName == null)
		{
			ErrorMessage = "Not existing crypto currency";
			return Page();
		}
		try
		{
			Currency = await new ApiCaller(context).MakeCall(CurrencyName);

			// Spara i en session
			HttpContext.Session.SetString("searchbutton", JsonConvert.SerializeObject(Currency));

		}
		catch (Exception ex)
		{
			ErrorMessage = ex.Message;
		}
		return Page();

	}

	public async Task<IActionResult> OnPostAddCurrency()
	{
		// Hämta sessionen som söktes
		var searchedJson = HttpContext.Session.GetString("searchbutton");
		if (searchedJson == null)
		{
			ErrorMessage = "No currency selected to AdD";
			return Page();
		}

		//Deserail för att spara i Db
		var currencyFromApi = JsonConvert.DeserializeObject<CryptoModel>(searchedJson);

		CryptoRepo cryptoRepo = new CryptoRepo(context);

		CryptoModel currencyToDb = new()
		{
			ApiId = currencyFromApi.ApiId,
			Name = currencyFromApi.Name,
			Price = currencyFromApi.Price,
		};

		await cryptoRepo.AddCurrency(currencyToDb);

		await OnGetAsync();

		return Page();
	}

}

/*
public class CryptoModel
{
    [Key]
    public int Id { get; set; }
    public string ApiId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal? Price { get; set; }
}
*/