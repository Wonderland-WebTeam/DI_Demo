using Autofac;
using Client.BusinessLayer;
using Client.Entities;
using Client.Strategy;
using System;
using System.Collections.Generic;

namespace Client
{
    class Program
    {
        private static void Main()
        {
            var products = new List<Product>
            {
                new Product {Price = 500},
                new Product {Price = 500}
            };

            // Factory + Singleton
            var shoppingCart1 = new ShoppingCart1();
            var totalPrice1 = shoppingCart1
                .Calculate(products, PriceDiscountEnum.Twenty);

            // Use DI
            var totalPrice2 = CompositionRoot()
                .Resolve<ShoppingCart2>()
                .Calculate(products, PriceDiscountEnum.Ten);

            Console.WriteLine(totalPrice1);
            Console.WriteLine(totalPrice2);
            Console.Read();
        }

        private static IContainer CompositionRoot()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ShoppingCart2>();

            // use factory DI
            builder.Register<IPriceDiscountStrategy>((c, p) =>
                {
                    var type = p.TypedAs<PriceDiscountEnum>();
                    return type switch
                    {
                        PriceDiscountEnum.Ten => new TenOffPriceDiscountStrategy(),
                        PriceDiscountEnum.Twenty => new TwentyOffPriceDiscountStrategy(),
                        _ => throw new ArgumentException("Invalid PriceDiscountEnum type")
                    };
                })
                .As<IPriceDiscountStrategy>();

            return builder.Build();
        }
    }
}
