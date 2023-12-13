using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    public class ShoppingCar
    {
        public List<object> Products { get; set; }

        public void AddProduct(object product)
        {
            if (Products == null)
                Products = new List<object>();

            Products.Add(product);
        }

        public decimal GetPrice()
        {
            decimal price = 0;

            foreach (var product in Products)
            {
                if (product is Sugar)
                {
                    var p = product as Sugar;

                    price += p.CalculatePrice();
                }
                else if (product is Apple)
                {
                    var p = product as Apple;

                    price += p.CalculatePrice();
                }
                else if (product is Potato)
                {
                    var p = product as Potato;

                    price += p.CalculatePrice();
                }
            }

            return price;
        }
    }
}
