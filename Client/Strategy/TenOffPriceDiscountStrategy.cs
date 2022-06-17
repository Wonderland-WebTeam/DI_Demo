using Client.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Client.Strategy
{
    public class TenOffPriceDiscountStrategy : IPriceDiscountStrategy
    {
        public decimal Calculate(IEnumerable<Product> products)
        {
            return products.Sum(d => d.Price) * 0.9M;
        }
    }
}