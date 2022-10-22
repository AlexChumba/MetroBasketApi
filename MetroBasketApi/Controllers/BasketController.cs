using MetroBasketApi.Models;
using MetroBasketApi.Models.Enums;
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
            var basketId = 0;
            try
            {
               basketId = await basketSevice.CreateBasket(customer, paysVAT);
            }
            catch (Exception ex)
            {
                logger.LogError("POST Basket - " + ex.Message);
            }
            return new ObjectResult(basketId);
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

        [HttpPut]
        [Route("/baskets/{id}")]
        public virtual async Task<IActionResult> Basket(int id, string status)
        {
            var basket = 0;
            BasketStatusEnum basketStatus = BasketStatusEnum.Open;
            try
            {
                if (status.ToLower() == nameof(BasketStatusEnum.Closed).ToLower())
                {
                    basketStatus = BasketStatusEnum.Closed;
                } else if (status.ToLower() != nameof(BasketStatusEnum.Open).ToLower())
                {
                    return new ObjectResult(basket);
                }
                basket = await basketSevice.UpdateStatus(id, basketStatus);
            }
            catch (Exception ex)
            {
                logger.LogError("PUT Basket - " + ex.Message);
            }
            return new ObjectResult(basket);
        }


        [HttpPost]
        [Route("/baskets/{id}/article-line")]
        public virtual async Task<IActionResult> Article(int id, string name, double price)
        {
            var articleId = 0;
            try
            {
                articleId = await basketSevice.AddArticle(name, price, id);
            }
            catch (Exception ex)
            {
                logger.LogError("POST Article - " + ex.Message);
            }
            return new ObjectResult(articleId);
        }
    }
}