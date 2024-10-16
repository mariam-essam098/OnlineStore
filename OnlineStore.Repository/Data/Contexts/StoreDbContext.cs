﻿using Microsoft.EntityFrameworkCore;
using OnlineStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Repository.Data.Contexts
{
	public class StoreDbContext :DbContext
	{


        public StoreDbContext(DbContextOptions<StoreDbContext> options):base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Apply On Configurations 

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		}


		public DbSet<Product> Products { get;set; } 
		public DbSet<ProductBrand> Brands { get;set; }

		public DbSet<ProductType> Types { get;set; }




	}
}
