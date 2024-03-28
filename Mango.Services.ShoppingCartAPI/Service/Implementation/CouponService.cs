using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service.Implementation
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CouponService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var getProduct = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var apicontent = await getProduct.Content.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<ResponseDto>(apicontent);
            if (response != null && response.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(response.Result));
            }
            return new CouponDto();
        }
    }
}
