using Mango.Web.Models;
using Mango.Web.Models.Dto.Product;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Mango.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
 
        public HomeController(ILogger<HomeController> logger, IProductService ProductService)
        {
            _productService = ProductService;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductDto> list = new();
            ResponseDto? responseDto = await _productService.GetAllProductsAsync();

            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(list);
        }

        [Authorize]
        public async Task<IActionResult> ProductDetails(int productId)
        {
            ProductDto? obj = new();
            ResponseDto? responseDto = await _productService.GetProductByIdAsync(productId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                obj = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(obj);
        }

        public async  Task<IActionResult> ProductIndex()
        {
            List<ProductDto> list = new();
            ResponseDto? responseDto = await _productService.GetAllProductsAsync();

            if (responseDto != null && responseDto.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(responseDto.Result));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }

            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
