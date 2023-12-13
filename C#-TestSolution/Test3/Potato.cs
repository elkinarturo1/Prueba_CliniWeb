using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Test3
{
    public class Potato : Products, IPrices
    {

        public Potato(int Quantity, decimal UnitPrice) : base(Quantity, UnitPrice)
        {
            GetItemDiscount();
            GetItemPrice();
        }

        public void GetItemDiscount()
        {

            if (_Quantity >= 12 && _Quantity < 24)
                _discount = 0.9M;
            else if (_Quantity >= 24)
                _discount = 0.8M;
        }

        public void GetItemPrice()
        {          
            decimal priceAjustment = 0.88M;

            _subPrice = _Quantity * _UnitPrice * priceAjustment;
            _subPrice = Math.Round(_subPrice, 2);
        }


    }
}
