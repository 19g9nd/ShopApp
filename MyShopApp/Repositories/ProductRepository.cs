using ConsoleApp5.Classes;
using Microsoft.EntityFrameworkCore;
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

		public ProductRepository(DbContextcs context)=>this.context = context;
		

		public IEnumerable<Product> Get(int id)
		{
			return this.context.Products
				.Where(p => p.Id == id)
				.ToList();
		}

		public void Add(Product product)
		{


			context.Products.Add(product);
			context.SaveChanges();


		}

		public void Update(Product newProduct)
		{
			context.Products.Update(newProduct);
			context.SaveChanges();
		}
		public void Delete(int id)
		{
			context.Products.Remove(context.Products.Find(id));
			context.SaveChanges();
		}
		public List<Product> GetAll()
		{
			return context.Products.Include(p => p.Status).ToList();
		}


	}
}
