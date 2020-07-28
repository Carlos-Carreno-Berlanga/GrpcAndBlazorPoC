using Bogus;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator
{
    public static class Generator
    {
         static Generator()
        {
            Randomizer.Seed = new Random(DateTime.Now.Millisecond);
        }


        public static IEnumerable<Samurai> NewSamurais()
        {
            return new Faker<Samurai>()
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .GenerateForever();
        }
    }
}
