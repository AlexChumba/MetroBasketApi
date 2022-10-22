using MetroBasketApi.Controllers;
using MetroBasketApi.Models;
using MetroBasketApi.Services;
using MetroBasketApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;

namespace MetroTests
{
    [TestClass]
    public class BasketControllerTests
    {

        [TestMethod]
        public async Task GetBasket_ReturnsCorrectValue()
        {
            var mock = new Mock<IBasketService>();
            var mocklog = new Mock<ILogger<BasketController>>();
            mock.Setup(p => p.GetBasket(1).Result).Returns(new Basket { Customer = "Ryan", CustomerPaysVat = false });
            BasketController controller = new BasketController(mocklog.Object, mock.Object);
            var result = await controller.Basket(1) as ObjectResult;
            var resultBasket = result.Value as Basket;
            Assert.AreEqual("Ryan", resultBasket.Customer);
        }
        [TestMethod]
        public async Task CreateBasket_ReturnsCorrectId()
        {
            var mock = new Mock<IBasketService>();
            var mocklog = new Mock<ILogger<BasketController>>();
            mock.Setup(p => p.CreateBasket("Adam", false).Result).Returns(1);
            BasketController controller = new BasketController(mocklog.Object, mock.Object);
            var result = await controller.Basket("Adam", false) as ObjectResult;
            Assert.AreEqual(1, result.Value);
        }
        [TestMethod]
        public async Task CreateArticle_ReturnsCorrectId()
        {
            var mock = new Mock<IBasketService>();
            var mocklog = new Mock<ILogger<BasketController>>();
            mock.Setup(p => p.AddArticle("Jukebox", 60, 1).Result).Returns(1);
            BasketController controller = new BasketController(mocklog.Object, mock.Object);
            var result = await controller.Article(1, "Jukebox", 60) as ObjectResult;
            Assert.AreEqual(1, result.Value);
        }
    }
}