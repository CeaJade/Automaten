using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class Product
    {
		private int price;
		private string name;

		//Gets price to the product as integer.
		public int Price
		{
			get { return price; }
			set { price = value; }
		}

		//Gets the name of the product as string.
		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		//Sets the name, price and stock amount of new product.
		public Product(string name, int price)
		{
			this.Price = price;
			this.Name = name;
		}
	}
}
