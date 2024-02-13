using CryptoScanner.Data;
using CryptoScanner.Data.Models;

namespace CryptoScanner.App.Services
{
	public class CoinsManager
	{
		private readonly AppDbContext context;
		private readonly CryptoRepo repo;
		public CoinsManager(AppDbContext context)
		{
			this.context = context;
			repo = new CryptoRepo(context);
		}

		/// <summary>
		/// /Gets all coins in descending order by price
		/// </summary>
		/// <returns></returns>
		public List<CryptoModel> GetDesc()

		{

			return repo.GetCurrency().OrderByDescending(c => c.Price).ToList();
		}
		/// <summary>
		/// Gets all coins in ascending order by price
		/// </summary>
		/// <returns></returns>
		public List<CryptoModel> GetAsc()

		{

			return repo.GetCurrency().OrderBy(c => c.Price).ToList();
		}

		/// <summary>
		/// Gets number coins in descending order by price
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public List<CryptoModel> GetDesc(int number)

		{

			return repo.GetCurrency().OrderByDescending(c => c.Price).Take(number).ToList();
		}
		/// <summary>
		/// Gets number coins in ascending order by price
		/// </summary>
		/// <param name="number"></param>
		/// <returns></returns>
		public List<CryptoModel> GetAsc(int number)

		{

			return repo.GetCurrency().OrderBy(c => c.Price).Take(number).ToList();
		}
	}
}
