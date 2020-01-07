using fundstrading.domain.Context;
using fundstrading.domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace fundstrading.repositories.tests
{
    [TestClass]
    public class ProductMappingRepositoryTest
    {
        [TestMethod]
        public void ChannelListTest()
        {
            var options = new DbContextOptionsBuilder<FundstradingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var ctx = new FundstradingContext(options))
            {
                ctx.Channel.Add(new Channel { Description = "Description", Appid = "Appid", Apikey = "Apikey", Userid = "Userid", Baseurl = "Baseurl" });
                ctx.SaveChanges();

                Assert.AreEqual(1, ctx.Channel.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);
                var results = repo.ChannelList().ToList();
                Assert.AreEqual(1, results.Count); // got row
                Assert.AreEqual("Description", results[0].Description); // got field value
            }
        }

        [TestMethod]
        public void ProductMappingListTest()
        {
            var options = new DbContextOptionsBuilder<FundstradingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var ctx = new FundstradingContext(options))
            {
                ctx.Channel.Add(new Channel { Description = "Description", Appid = "Appid", Apikey = "Apikey", Userid = "Userid", Baseurl = "Baseurl" });
                ctx.SaveChanges();
                ctx.Productmapping.Add(new Productmapping { Incoming = "Incoming", Outgoing = "Outgoing", Channelid = ctx.Channel.FirstOrDefault().Id });
                ctx.SaveChanges();

                Assert.AreEqual(1, ctx.Channel.Count());
                Assert.AreEqual(1, ctx.Productmapping.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);
                var task = repo.ProductMappingList();
                task.Wait();
                var results = task.Result.ToList();
                Assert.AreEqual(1, results.Count); // got row
                Assert.AreEqual("Incoming", results[0].Incoming); // got field value
                Assert.IsNotNull(results[0].Channel);
            }
        }

        [TestMethod]
        public void FindProductMappingTest()
        {
            var options = new DbContextOptionsBuilder<FundstradingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var ctx = new FundstradingContext(options))
            {
                ctx.Channel.Add(new Channel { Description = "Description", Appid = "Appid", Apikey = "Apikey", Userid = "Userid", Baseurl = "Baseurl" });
                ctx.SaveChanges();
                ctx.Productmapping.Add(new Productmapping { Id =1, Incoming = "Incoming", Outgoing = "Outgoing", Channelid = ctx.Channel.FirstOrDefault().Id });
                ctx.SaveChanges();

                Assert.AreEqual(1, ctx.Channel.Count());
                Assert.AreEqual(1, ctx.Productmapping.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);
                var task = repo.FindProductMapping(1);
                task.Wait();
                Productmapping productMapping = task.Result;
                Assert.IsNotNull(productMapping);
                Assert.AreEqual(1, productMapping.Id);
                Assert.IsNotNull(productMapping.Channel);

                task = repo.FindProductMapping(2);
                task.Wait();
                productMapping = task.Result;
                Assert.IsNull(productMapping);
            }
        }

        [TestMethod]
        public void CreateProductMappingTest()
        {
            var options = new DbContextOptionsBuilder<FundstradingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            int channelId;

            // Insert seed data into the database using one instance of the context
            using (var ctx = new FundstradingContext(options))
            {
                ctx.Channel.Add(new Channel { Description = "Description", Appid = "Appid", Apikey = "Apikey", Userid = "Userid", Baseurl = "Baseurl" });
                ctx.SaveChanges();

                channelId = ctx.Channel.FirstOrDefault().Id;

                Assert.AreEqual(1, ctx.Channel.Count());
                Assert.AreEqual(0, ctx.Productmapping.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);

                Productmapping productMapping = new Productmapping()
                {
                    Incoming = "Incoming",
                    Outgoing = "Outgoing",
                    Channelid = channelId
                };

                repo.CreateProductMapping(productMapping);

                var task = repo.ProductMappingList();
                task.Wait();
                var results = task.Result.ToList();
                Assert.AreEqual(1, results.Count); // got row
                Assert.AreEqual("Incoming", results[0].Incoming); // got field value
                Assert.IsNotNull(results[0].Channel);
            }
        }

        [TestMethod]
        public void DeleteProductMappingTest()
        {
            var options = new DbContextOptionsBuilder<FundstradingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            Productmapping productMapping;

            // Insert seed data into the database using one instance of the context
            using (var ctx = new FundstradingContext(options))
            {
                ctx.Channel.Add(new Channel { Description = "Description", Appid = "Appid", Apikey = "Apikey", Userid = "Userid", Baseurl = "Baseurl" });
                ctx.SaveChanges();

                productMapping = new Productmapping { Id = 1, Incoming = "Incoming", Outgoing = "Outgoing", Channelid = ctx.Channel.FirstOrDefault().Id };

                ctx.Productmapping.Add(productMapping);
                ctx.SaveChanges();

                Assert.AreEqual(1, ctx.Channel.Count());
                Assert.AreEqual(1, ctx.Productmapping.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);
                repo.DeleteProductMapping(productMapping);

                var task = repo.FindProductMapping(1);
                task.Wait();
                productMapping = task.Result;
                Assert.IsNull(productMapping);
            }
        }

        [TestMethod]
        public void UpdateProductMappingTest()
        {
            var options = new DbContextOptionsBuilder<FundstradingContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            Productmapping productMapping;
            Channel channel2;

            // Insert seed data into the database using one instance of the context
            using (var ctx = new FundstradingContext(options))
            {
                Channel channel1 = new Channel { Id = 1, Description = "Description", Appid = "Appid", Apikey = "Apikey", Userid = "Userid", Baseurl = "Baseurl" };
                channel2 = new Channel { Id = 2, Description = "Description2", Appid = "Appid2", Apikey = "Apikey2", Userid = "Userid2", Baseurl = "Baseurl2" };

                ctx.Channel.Add(channel1);
                ctx.Channel.Add(channel2);
                ctx.SaveChanges();

                productMapping = new Productmapping { Id = 1, Incoming = "Incoming", Outgoing = "Outgoing", Channelid = 1 };

                ctx.Productmapping.Add(productMapping);
                ctx.SaveChanges();

                Assert.AreEqual(2, ctx.Channel.Count());
                Assert.AreEqual(1, ctx.Productmapping.Count());
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);

                productMapping.Incoming = "I";
                productMapping.Outgoing = "O";
                productMapping.Channel = channel2;

                repo.UpdateProductMapping(productMapping);
            }

            // Use a clean instance of the context to run the test
            using (var ctx = new FundstradingContext(options))
            {
                ProductMappingRepository repo = new ProductMappingRepository(ctx);

                var task = repo.FindProductMapping(1);
                task.Wait();
                Assert.IsNotNull(task.Result);
                Assert.AreEqual("I", task.Result.Incoming); // got field value
                Assert.AreEqual("O", task.Result.Outgoing); // got field value
                Assert.IsNotNull(task.Result.Channel);
                Assert.AreEqual(2, task.Result.Channelid); // got field value
            }
        }
    }
}
