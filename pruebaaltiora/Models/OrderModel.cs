using System;
namespace pruebaaltiora.Models
{
	public class OrderModel
	{
		public string Code { get; set; }
		public List<ProductModel> Products { get; set; }
		public DateTime Date { get; set; }

		public OrderModel()
		{
		}
    }
}

