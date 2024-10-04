using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Entities
{
	public class BaseEntity<Tkey>
	{
		//Foriegn key for Brand 
		public Tkey Id { get; set; }

		public DateTime CreateAt { get; set; }=DateTime.UtcNow;








	}
}
