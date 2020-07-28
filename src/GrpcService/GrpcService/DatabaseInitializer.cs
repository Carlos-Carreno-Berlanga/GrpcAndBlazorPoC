using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace GrpcService
{
    public static class DatabaseInitializer
    {

        public static async Task InitializeAsync(SamuraiContext dbContext)
        {
            // Drop & re-create DB
            //dbContext.Database.EnsureDeleted();
            await dbContext.Database.EnsureCreatedAsync();
            //dbContext.Database.EnsureCreatedAsync

            // Data is already seeded?
            //if (dbContext.Orders.Any())
            //    return;

            // Do the initialization

            //DataGenerator.KnownCurrencies
            //    .Select(code => new Currency { Code = code, Name = $"{code} currency" })
            //    .ForEach(currency => dbContext.Currencies.Add(currency));
            //dbContext.SaveChanges();
            //DataGenerator.KnownUnitsOfMeasure
            //    .Select(code => new UnitOfMeasure { Code = code, Name = $"{code} uom" })
            //    .ForEach(uom => dbContext.UnitsOfMeasure.Add(uom));
            //dbContext.SaveChanges();

            //DataGenerator.NewOrders()
            //    .Take(20)
            //    .ForEach(order => dbContext.Orders.Add(order));
            //dbContext.SaveChanges();

            //dbContext.SubAccounts.Take(4)
            //    .ForEach(subAccount => dbContext.OrdersLinks.Add(DataGenerator.NewOrderLink(subAccount)));

            dbContext.SaveChanges();
        }
    }
}
