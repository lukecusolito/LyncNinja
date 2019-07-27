using LyncNinja.Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace LyncNinja.Tests.Helpers.Data
{
    public class LyncNinjaContextSetup
    {
        public static LyncNinjaContext InitialiseLyncNinjaContext()
        {
            var options = new DbContextOptionsBuilder<LyncNinjaContext>()
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new LyncNinjaContext(options);

            context.AddRange(DbSets.LinkedResources);
            context.SaveChanges();

            return context;
        }

        public static LyncNinjaContext InitialiseEmptyLyncNinjaContext()
        {
            var options = new DbContextOptionsBuilder<LyncNinjaContext>()
                .UseLazyLoadingProxies()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new LyncNinjaContext(options);
        }
    }
}
