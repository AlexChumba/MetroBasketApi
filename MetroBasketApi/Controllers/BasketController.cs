using MetroBasketApi.Models;
using MetroBasketApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace MetroBasketApi.Controllers
{
    [ApiController]
    [Route("metro-api")]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> logger;
        private readonly IBasketService basketSevice;

        public BasketController(ILogger<BasketController> logger, IBasketService ibasketService)
        {
            basketSevice = ibasketService; 
            this.logger = logger;
        }

        [HttpPost]
        [Route("/baskets")]
        public virtual async Task<IActionResult> Basket( string customer, bool paysVAT)
        {
            var basket = 0;
            try
            {
               basket = await basketSevice.CreateBasket(customer, paysVAT);
            }
            catch (Exception ex)
            {
                logger.LogError("POST Basket - " + ex.Message);
            }
            return new ObjectResult(basket);
        }

        [HttpGet]
        [Route("/baskets/{id}")]
        public virtual async Task<IActionResult> Basket(int id)
        {
            var basket = new Basket();
            try
            {
                basket = await basketSevice.GetBasket(id);
            }
            catch (Exception ex)
            {
                logger.LogError("GET Basket - " + ex.Message);
            }
            return new ObjectResult(basket);
        }
    }
}