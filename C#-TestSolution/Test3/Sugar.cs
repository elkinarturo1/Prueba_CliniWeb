using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    public class Sugar : Products, IPrices
    {

        public Sugar(int Quantity, decimal UnitPrice) : base(Quantity, UnitPrice)
        {
            GetItemDiscount();
            GetItemPrice();
        }        

        public void GetItemDiscount()
        {
            _discount = 1;
        }

        public void GetItemPrice()
        {            
            _subPrice = _Quantity * _UnitPrice;
            _subPrice = Math.Round(_subPrice, 2);
        }

    }
}
