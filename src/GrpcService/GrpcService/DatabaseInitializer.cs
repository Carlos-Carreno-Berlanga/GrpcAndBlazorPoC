using Data;
using DataGenerator;
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

            await dbContext.Database.EnsureCreatedAsync();
            //dbContext.Database.EnsureCreatedAsync

            // Data is already seeded?
            if (dbContext.Samurais.Any() == false)
            {

                await dbContext.Samurais.AddRangeAsync(Generator.NewSamurais().Take(10000));
            }
            
            dbContext.SaveChanges();
        }
    }
}
