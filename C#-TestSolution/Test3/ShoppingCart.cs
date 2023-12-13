using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    public class ShoppingCart
    {
        public List<Products> Products { get; set; }

        public void AddProduct(Products product)
        {
            if (Products == null)
                Products = new List<Products>();

            Products.Add(product);
        }

        public void GetPrice()
        {
            decimal price = 0;

            foreach (Products product in Products)
            {               
                price += product.GetPrice();
            }

            Console.WriteLine(price);
            Console.ReadKey();

        }

    }
}
