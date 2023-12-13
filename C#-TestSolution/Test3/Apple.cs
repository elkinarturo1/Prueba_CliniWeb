using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    public class Apple : Products, IPrices
    {


        List<Products> lstProducts = new List<Products> ();

        public Apple(int Quantity, decimal UnitPrice) : base(Quantity, UnitPrice)
        {
            GetItemDiscount();
            GetItemPrice();
        }

        public void GetItemDiscount()
        {            
            if (_Quantity > 12)
                _discount = 0.9M;
            else
                _discount = 1;
        }

        public void GetItemPrice()
        {
           decimal priceAjustment = 0.98M;

            _subPrice = _Quantity * _UnitPrice * priceAjustment;
            _subPrice = Math.Round(_subPrice, 2);

        }    


    }
}
