using Client.Entities;
using System.Collections.Generic;

namespace Client.BusinessLayer
{
    public class ShoppingCart1
    {
        public decimal Calculate(
            IEnumerable<Product> products,
            PriceDiscountEnum priceDiscountEnum)
        {
            return DiscountStrategyFactory.Instance
                .DiscountStrategy(priceDiscountEnum)
                .Calculate(products);
        }
    }
}