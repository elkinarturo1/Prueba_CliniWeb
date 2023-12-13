using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    /*
     * The main purpose of this exercise is to refactor the shopping cart to be more object oriented.
     * A developer should be able to add a new product without the need to refactor any 
     * core ShoppingCart.cs logic. For example, product price logic should be isolated.
     * 
     * IMPORTANT NOTE: Try to avoid any duplicated code between the classes
     * IMPORTANT NOTE: Use Responsibility-driven design
     */
    class Program
    {
        static void Main(string[] args)
        {
            Products potato = new Potato (24, 0.8m );
            Products sugar = new Sugar ( 1, 1.0m );
            var shoppingCart = new ShoppingCart();

            shoppingCart.AddProduct(potato);
            shoppingCart.AddProduct(sugar);

            shoppingCart.GetPrice();

            Console.ReadKey();
        }
    }
}
