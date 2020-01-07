using fundstrading.common;
using fundstrading.domain.Context;
using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace fundstrading.repositories.tests
{
    [TestClass]
    public class FixMessageRepositoryTest
    {
        [TestMethod]
        public void SearchTest()
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
                    ctx.Fixmessage.Add(new Fixmessage { Datetime = DateTime.Now.AddSeconds(i)});
                    ctx.SaveChanges();
                }
                Assert.AreEqual(TAKE * 2, ctx.Fixmessage.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                FixMessageRepository repo = new FixMessageRepository(ctx);
                var task = repo.SearchAsync(TAKE);
                task.Wait();
                var results = task.Result.ToList();
                Assert.AreEqual(TAKE, results.Count); // test take
                Assert.IsTrue(results[0].Datetime > results[1].Datetime); // test descending sort
            }
        }

        [TestMethod]
        public void SearchOrderTest()
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
                var task = repo.SearchOrderAsync(now, "orderId", 0);
                task.Wait();
                var results = task.Result.ToList();
                Assert.AreEqual(2, results.Count); // test where
                Assert.IsTrue(results[0].Datetime < results[1].Datetime); // test ascending sort
            }
        }

        [TestMethod]
        public void SearchOrderAndRegistIdTest()
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
                var task = repo.SearchOrderAndRegistIdAsync(now, "orderId", "registId",  0);
                task.Wait();
                var results = task.Result.ToList();
                Assert.AreEqual(2, results.Count); // test where
                Assert.IsTrue(results[0].Datetime < results[1].Datetime); // test ascending sort
                Assert.AreEqual(Constants.SOH + Constants.TAG11 + "orderId" + Constants.SOH, results[0].Raw); // found by orderId
                Assert.AreEqual(Constants.SOH + Constants.TAG513 + "registId" + Constants.SOH, results[1].Raw); // found by registId
            }
        }

    }
}
