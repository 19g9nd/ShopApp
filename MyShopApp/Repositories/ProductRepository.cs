using ConsoleApp5.Classes;
using MyShopApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopApp.Repositories
{
    public class ProductRepository 
    {
		private readonly DbContextcs context;

		public ProductRepository()
		{
			this.context = new DbContextcs();
		}

		public IEnumerable<Product> Get(int id)
		{
			return this.context.Products
				.Where(p => p.Id == id)
				.ToList();
		}
	}
}
