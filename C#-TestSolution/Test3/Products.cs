using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    public class Products
    {
        protected int _Quantity { get; set; }
        protected decimal _UnitPrice { get; set; }      
        protected decimal _discount { get; set; }

        protected decimal _subPrice { get; set; }

        public Products(int Quantity, decimal UnitPrice)
        {
            _Quantity = Quantity;
            _UnitPrice = UnitPrice;            
            _discount = 0;
        }

        public decimal GetPrice()
        {
            return (_UnitPrice * _discount);
        }

    }
}
