using Disaster_Allievation_Foundation_.Controllers;
using Disaster_Allievation_Foundation_.Data;
using Disaster_Allievation_Foundation_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using static Disaster_Allievation_Foundation_.Data.ApplicationDbContext;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public async Task Allocation_Goods_ReturnUser_ID()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                // Add a record with All_GoodsID = 1 to the in-memory database
                var expectedRecord = new Allocation_Goods { All_GoodsID = 1, Disaster_ID = 1, GoodsDonation_ID = 1, Goods_Items = 4 };
                context.Allocation_Goods.Add(expectedRecord);
                context.SaveChanges();

                var controller = new Allocation_GoodsController(context);

                // Act
                var result = await controller.Details(1);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));

                // Check if the model in the ViewResult is of type Allocation_Goods
                var model = ((ViewResult)result).Model as Allocation_Goods;
                Assert.IsNotNull(model);

                // Check if the properties of the model match the expected values
                Assert.AreEqual(expectedRecord.All_GoodsID, model.All_GoodsID);
                Assert.AreEqual(expectedRecord.Disaster_ID, model.Disaster_ID);
                Assert.AreEqual(expectedRecord.GoodsDonation_ID, model.GoodsDonation_ID);
                Assert.AreEqual(expectedRecord.Goods_Items, model.Goods_Items);
            }
        }

        [TestMethod]
        public void TestCheckListDecreasesLimitBalance()
        {
            // Arrange
            int initialLimitBalance = 10;
            int limit = 5;

            var controller = new Allocation_MoneyController(null); // Pass null as the ApplicationDbContext for this example

            // Act
            controller.LimitBalance = initialLimitBalance;
            controller.checkList(limit);

            // Assert
            Assert.AreEqual(initialLimitBalance - limit, controller.LimitBalance);
        }

        [TestMethod]
        public void TestCheckListWithNegativeLimitThrowsException()
        {
            // Arrange
            int limit = -5;
            var controller = new Allocation_MoneyController(null);

            // Act & Assert
            try
            {
                controller.checkList(limit);
                Assert.Fail("Expected exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
                // Optionally, add more assertions or log the exception for further investigation
            }
        }

        [TestMethod]
        public void TestCheckListWithLimitExceedsThrowsException()
        {
            // Arrange
            int limit = 15;
            var controller = new Allocation_MoneyController(null);

            // Act & Assert
            try
            {
                controller.checkList(limit);
                Assert.Fail("Expected exception not thrown.");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
                // Optionally, add more assertions or log the exception for further investigation
            }
        }
    }
}
