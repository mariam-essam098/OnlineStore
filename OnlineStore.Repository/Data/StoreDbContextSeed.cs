using OnlineStore.Core.Entities;
using OnlineStore.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineStore.Repository.Data
{
	public static class StoreDbContextSeed
	{
		public async  static Task SeedAsync(StoreDbContext _context)
		{
			//Brand


			#region brands

			//Read Data From Json File
			var brandsData = File.ReadAllText(path: @"..\OnlineStore.Repository\Data\DataSeed\brands.json");

			//Convert string to list<T>

			var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);


			if (brands is not null)
			{

				await _context.Brands.AddRangeAsync(brands);


				await _context.SaveChangesAsync();

			}
			#endregion

			#region Types

			//Read Data From Json File
			var typesData = File.ReadAllText(path: @"..\OnlineStore.Repository\Data\DataSeed\types.json");

			//Convert string to list<T>

			var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);


			if (types is not null)
			{

				await _context.Types.AddRangeAsync(types);


				await _context.SaveChangesAsync();

			}
			#endregion


			#region Product




			//Read Data From Json File
			var productsData = File.ReadAllText(path: @"..\OnlineStore.Repository\Data\DataSeed\products.json");

			//Convert string to list<T>

			var products = JsonSerializer.Deserialize<List<Product>>(productsData);


			if (products is not null)
			{

				await _context.Products.AddRangeAsync(products);


				await _context.SaveChangesAsync();

			}
			#endregion







		}

	}
}
