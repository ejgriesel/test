using fundstrading.common;
using fundstrading.domain.Context;
using fundstrading.domain.Models;
using fundstrading.domain.Services;
using fundstrading.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fundstrading.services.tests
{
    [TestClass]
    public class FixMessageSearchTest
    {
        [TestMethod]
        public void SearchAsyncTest()
        {
            Task.Run(async () =>
            {
                const int TAKE = 10;

                var options = new DbContextOptionsBuilder<FundstradingContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

                // Insert seed data into the database using one instance of the context
                using (var ctx = new FundstradingContext(options))
                {
                    for (int i = 0; i < TAKE * 2; i++)
                    {
                        ctx.Fixmessage.Add(new Fixmessage { Datetime = DateTime.Now.AddSeconds(i) });
                        ctx.SaveChanges();
                    }
                    Assert.AreEqual(TAKE * 2, ctx.Fixmessage.Count());
                }

                // Use a clean instance of the context to run the test
                using (var ctx = new FundstradingContext(options))
                {
                    FixMessageRepository repo = new FixMessageRepository(ctx);

                    SearchFixMessageService searchFixMessageService = new SearchFixMessageService(repo);
                    IEnumerable<Fixmessage> searchResult = await searchFixMessageService.SearchAsync(TAKE);

                    Assert.AreEqual(TAKE, searchResult.Count());
                }
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void SearchOrderAsyncTest()
        {
            Task.Run(async () =>
            {
                DateTime now = DateTime.Now;

                var options = new DbContextOptionsBuilder<FundstradingContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

                // Insert seed data into the database using one instance of the context
                using (var ctx = new FundstradingContext(options))
                {
                    ctx.Fixmessage.Add(new Fixmessage { Datetime = now.AddSeconds(0), Raw = Constants.SOH + Constants.TAG11 + "orderId" + Constants.SOH });
                    ctx.Fixmessage.Add(new Fixmessage { Datetime = now.AddSeconds(1), Raw = Constants.SOH + Constants.TAG11 + "orderId" + Constants.SOH });
                    ctx.Fixmessage.Add(new Fixmessage { Datetime = now.AddSeconds(2), Raw = Constants.SOH + Constants.TAG11 + "orderId2" + Constants.SOH });
                    ctx.SaveChanges();

                    Assert.AreEqual(3, ctx.Fixmessage.Count());
                }

                // Use a clean instance of the context to run the test
                using (var ctx = new FundstradingContext(options))
                {
                    FixMessageRepository repo = new FixMessageRepository(ctx);

                    SearchFixMessageService searchFixMessageService = new SearchFixMessageService(repo);
                    IEnumerable<Fixmessage> searchResult = await searchFixMessageService.SearchOrderAsync(now, "orderId", 0);

                    Assert.AreEqual(2, searchResult.Count());
                }
            }).GetAwaiter().GetResult();
        }

        [TestMethod]
        public void SearchOrderAndregistIdTest()
        {
            Task.Run(async () =>
            {
                DateTime now = DateTime.Now;

                var options = new DbContextOptionsBuilder<FundstradingContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                    .Options;

                // Insert seed data into the database using one instance of the context
                using (var ctx = new FundstradingContext(options))
                {
                    ctx.Fixmessage.Add(new Fixmessage { Datetime = now.AddSeconds(0), Raw = Constants.SOH + Constants.TAG11 + "orderId" + Constants.SOH });
                    ctx.Fixmessage.Add(new Fixmessage { Datetime = now.AddSeconds(1), Raw = Constants.SOH + Constants.TAG513 + "registId" + Constants.SOH });
                    ctx.SaveChanges();

                    Assert.AreEqual(2, ctx.Fixmessage.Count());
                }

                // Use a clean instance of the context to run the test
                using (var ctx = new FundstradingContext(options))
                {
                    FixMessageRepository repo = new FixMessageRepository(ctx);

                    SearchFixMessageService searchFixMessageService = new SearchFixMessageService(repo);
                    IEnumerable<Fixmessage> searchResult = await searchFixMessageService.SearchOrderAndRegistIdAsync(now, "orderId", "registId", 0);

                    Assert.AreEqual(2, searchResult.Count());
                }
            }).GetAwaiter().GetResult();
        }
    }
}
