using Mango.Web.Models;
using Mango.Web.Models.Dto.Product;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }
        public async Task<IActionResult> ProductIndex()
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




        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responseDto = await _productService.CreateProductAsync(model);

                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Product Created Successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = responseDto?.Message;
                }

            }

            return View(model);
        }




        public async Task<IActionResult> ProductDelete(int ProductId)
        {
            ResponseDto? responseDto = await _productService.GetProductByIdAsync(ProductId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }


            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto ProductDto)
        {
            ResponseDto? responseDto = await _productService.DeleteProductAsync(ProductDto.ProductId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Product Deleted Successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }


            return View(ProductDto);
        }




        public async Task<IActionResult> ProductEdit(int ProductId)
        {
            ResponseDto? responseDto = await _productService.GetProductByIdAsync(ProductId);

            if (responseDto != null && responseDto.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(responseDto.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }


            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto ProductDto)
        {
            ResponseDto? responseDto = await _productService.UpdateProductAsync(ProductDto);

            if (responseDto != null && responseDto.IsSuccess)
            {
                TempData["success"] = "Product Updated Successfully";
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = responseDto?.Message;
            }


            return View(ProductDto);
        }


    }
}








