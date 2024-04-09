using Mango.Web.Models;
using Mango.Web.Models.Dto.Cart;
using Mango.Web.Models.Dto.Coupon;

namespace Mango.Web.Service.IService
{
    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto); 
    }
}
