using CryptoScanner.App;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CryptoScanner.UI.Pages;

public class IndexModel : PageModel
{

    public string? ErrorMessage { get; set; }
    [BindProperty]
    public string? CurrencyName { get; set; }

    public string? AddCurrency { get; set; }


    public void OnGet() // async Task senare
    {

    }


    public void OnPost() // async Task senare
    {
        public void OnGet()
        {
            ApiCaller apiCaller = new ApiCaller();
            apiCaller.MakeCall("01coin");
        }
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