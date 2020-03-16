using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automaten
{
    class ProductHolder
    {
        private Product[] products;
        private int position;

        public Product[] Products
        {
            get { return products; }
            set { products = value; }
        }
        public int Position
        {
            get { return position; }
            set { position = value; }
        }


        public ProductHolder(int maxProducts)
        {
            products = new Product[maxProducts];
            position = 0;
        }


        public void AddProduct(Product product)
        {
            if (products.Length + 1 > position)
            {
                products[position] = product;
                position++;
            }
        }


        public Product PeekProduct()
        {
            Product productToReturn = products[position - 1];
            return productToReturn;
        }
        
        
        public Product GetProduct()
        {
            Product productToReturn = products[position - 1];
            position--;
            return productToReturn;
        }
    }
}
