using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class CommonService<T> where T : class
	{
		TestDbContext _ctx;

		public CommonService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public PagedList<T> List(int page)
		{
			page = page <= 0 ? 1 : page;
			var products = _ctx.Set<T>().Skip((page - 1) * 10).Take(11).ToList();
			return new PagedList<T>() { HasNext = products.Count > 10, TotalCount = _ctx.Products.Count(), Items = products.Take(10).ToList() };
		}

	}
}
