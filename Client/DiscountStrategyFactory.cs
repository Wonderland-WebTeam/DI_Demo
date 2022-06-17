using Client.Entities;
using Client.Strategy;
using System;

namespace Client
{
    public sealed class DiscountStrategyFactory
    {
        private DiscountStrategyFactory()
        {
        }

        private static readonly Lazy<DiscountStrategyFactory> Lazy =
            new Lazy<DiscountStrategyFactory>(() => new DiscountStrategyFactory());

        public static DiscountStrategyFactory Instance => Lazy.Value;

        public IPriceDiscountStrategy DiscountStrategy(PriceDiscountEnum priceDiscountEnum)
        {
            return priceDiscountEnum switch
            {
                PriceDiscountEnum.Ten => new TenOffPriceDiscountStrategy(),
                PriceDiscountEnum.Twenty => new TwentyOffPriceDiscountStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(priceDiscountEnum), priceDiscountEnum, null)
            };
        }
    }
}