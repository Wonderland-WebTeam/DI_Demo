using Client.Entities;
using System.Collections.Generic;

namespace Client.Strategy
{
    public interface IPriceDiscountStrategy
    {
        decimal Calculate(IEnumerable<Product> products);
    }
}