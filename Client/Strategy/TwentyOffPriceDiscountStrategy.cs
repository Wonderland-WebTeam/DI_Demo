using Client.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Client.Strategy
{
    public class TwentyOffPriceDiscountStrategy : IPriceDiscountStrategy
    {
        public decimal Calculate(IEnumerable<Product> products)
        {
            return products.Sum(d => d.Price) * 0.8M;
        }
    }
}