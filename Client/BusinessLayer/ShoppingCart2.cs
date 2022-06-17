using Client.Entities;
using Client.Strategy;
using System;
using System.Collections.Generic;

namespace Client.BusinessLayer
{
    public class ShoppingCart2
    {
        private readonly Func<PriceDiscountEnum, IPriceDiscountStrategy> _priceDiscountStrategy;

        public ShoppingCart2(Func<PriceDiscountEnum, IPriceDiscountStrategy> priceDiscountStrategy)
        {
            _priceDiscountStrategy = priceDiscountStrategy;
        }

        public decimal Calculate(IEnumerable<Product> products, PriceDiscountEnum priceDiscountEnum)
        {
            return _priceDiscountStrategy(priceDiscountEnum).Calculate(products);
        }
    }
}