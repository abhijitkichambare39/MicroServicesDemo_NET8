using Mango.Web.Models;
using Mango.Web.Models.Dto.Product;


namespace Mango.Web.Service.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> GetAllProductsAsync();
       // Task<ResponseDto?> GetProductByCodeAsync(string ProductCode);
        Task<ResponseDto?> GetProductByIdAsync(int ProductId);
        Task<ResponseDto?> CreateProductAsync(ProductDto ProductDto);
        Task<ResponseDto?> UpdateProductAsync(ProductDto ProductDto);
        Task<ResponseDto?> DeleteProductAsync(int ProductId);
    }
}
