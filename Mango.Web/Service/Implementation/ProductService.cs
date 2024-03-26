using Mango.Web.Models;
using Mango.Web.Models.Dto.Product;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #region GET     

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/product"
            });
        }

        //public async Task<ResponseDto?> GetProductByCodeAsync(string ProductCode)
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = SD.ApiType.GET,
        //        Url = SD.ProductApiBase + "/api/product/GetByCode/" + ProductCode
        //    });
        //}

        public async Task<ResponseDto?> GetProductByIdAsync(int ProductId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProductApiBase + "/api/product/" + ProductId
            });
        }

        #endregion



        #region CRUD        

        public async Task<ResponseDto?> CreateProductAsync(ProductDto ProductDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = ProductDto,
                Url = SD.ProductApiBase + "/api/product"
            });
        }


        public async Task<ResponseDto?> UpdateProductAsync(ProductDto ProductDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = ProductDto,
                Url = SD.ProductApiBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> DeleteProductAsync(int ProductId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.ProductApiBase + "/api/product/" + ProductId
            });
        }

        #endregion
    }
}
