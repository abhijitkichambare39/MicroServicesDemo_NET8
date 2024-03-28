using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _responseDto = new ResponseDto();
            _mapper = mapper;
        }


        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objlist = _db.Coupons.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<CouponDto>>(objlist);
                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }



        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponId == id);
                _responseDto.Result = _mapper.Map<CouponDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpGet]
        [Route("GetByCode/{couponcode}")]
        public ResponseDto GetByCode(string couponcode)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponCode.ToLower().Trim() == couponcode.ToLower().Trim());
                _responseDto.Result = _mapper.Map<CouponDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ResponseDto Post([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto); //_db.Coupons.First(x => x.CouponCode.ToLower().Trim() == couponcode.ToLower().Trim());
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons ON"); 
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons OFF");
                _responseDto.Result = _mapper.Map<CouponDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] CouponDto couponDto)
        {
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto); //_db.Coupons.First(x => x.CouponCode.ToLower().Trim() == couponcode.ToLower().Trim());
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons ON"); 
                _db.Coupons.Update(obj);
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons OFF");
                _responseDto.Result = _mapper.Map<CouponDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Coupon obj = _db.Coupons.First(x => x.CouponId == id);
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons ON"); 
                _db.Coupons.Remove(obj);
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Coupons OFF");
                //_responseDto.Result = _mapper.Map<CouponDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }
    }
}
