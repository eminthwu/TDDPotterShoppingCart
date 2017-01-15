using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterShoopinCart
{
    interface ICaculatePrice
    {
        double DiscountValue { get; }

        Tuple<int,IEnumerable<int>> CaculatePrice(IEnumerable<HarryPotter> books, ref IEnumerable<int> caculated);
    }
}
