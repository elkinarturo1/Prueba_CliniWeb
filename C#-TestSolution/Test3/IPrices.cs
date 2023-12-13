using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test3
{
    public interface IPrices
    {
        decimal GetPrice();

        void GetItemPrice();

        void GetItemDiscount();

    }
}
