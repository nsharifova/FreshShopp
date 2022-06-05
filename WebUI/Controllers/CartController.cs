using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductManager _productManager;

        public CartController(IProductManager productManager)
        {
            _productManager = productManager;
        }


        public async Task <ActionResult> Index()
        {
            var cookieData = Request.Cookies["myCookie"];

            if (cookieData != null && cookieData != "")
            {

                List<int> productIds = cookieData.Split("-",StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
                List<Product> productList = await _productManager.GetByIds(productIds.Distinct());
                CartVM vm = new()
                {
                    ProIds = productIds,
                    CartItems = productList,
                };
                return View(vm);
            }



            return View();
        }
    }
}
