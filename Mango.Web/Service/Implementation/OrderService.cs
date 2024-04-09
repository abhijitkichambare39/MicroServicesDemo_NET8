using Mango.Web.Models;
using Mango.Web.Models.Dto.Cart;
using Mango.Web.Models.Dto.Coupon;
using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;

        public OrderService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        #region GET     

     

        #endregion



        #region CRUD        
               
        public async Task<ResponseDto?> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderApiBase + "/api/order/CreateOrder"
            });
        }

        #endregion
    }
}
