using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Entities
{
	public class Product :BaseEntity<int>
	{
      

        public string Name { get; set; }

        public string Description { get; set; }

        public string PictureUrl { get; set; }


        public  decimal Price { get; set; }

        //Foriegn key for Brand 
        public int? BrandId { get; set; }

        //Navigational property

        public ProductBrand Brand { get; set; }

		//Foriegn key for type 
		public int? TypeId { get; set; }

		public ProductType Type { get; set; }



    }
}
