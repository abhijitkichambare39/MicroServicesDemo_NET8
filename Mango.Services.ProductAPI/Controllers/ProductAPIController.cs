using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _responseDto;
        private IMapper _mapper;
        public ProductAPIController(AppDbContext db, IMapper mapper)
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
                IEnumerable<Product> objlist = _db.Products.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>>(objlist);
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
                Product obj = _db.Products.First(x => x.ProductId == id);
                _responseDto.Result = _mapper.Map<ProductDto>(obj);

                return _responseDto;
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }


        //[HttpGet]
        //[Route("GetByCode/{Productcode}")]
        //public ResponseDto GetByCode(string Productcode)
        //{
        //    try
        //    {
        //        Product obj = _db.Products.First(x => x.ProductCode.ToLower().Trim() == Productcode.ToLower().Trim());
        //        _responseDto.Result = _mapper.Map<ProductDto>(obj);

        //        return _responseDto;
        //    }
        //    catch (Exception ex)
        //    {
        //        _responseDto.IsSuccess = false;
        //        _responseDto.Message = ex.Message;
        //    }
        //    return _responseDto;
        //}


        [HttpPost]
        [Authorize(Roles ="ADMIN")]
        public ResponseDto Post([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto); //_db.Products.First(x => x.ProductCode.ToLower().Trim() == Productcode.ToLower().Trim());
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON"); 
                _db.Products.Add(obj);
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products OFF");
                _responseDto.Result = _mapper.Map<ProductDto>(obj);

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
        public ResponseDto Put([FromBody] ProductDto ProductDto)
        {
            try
            {
                Product obj = _mapper.Map<Product>(ProductDto); //_db.Products.First(x => x.ProductCode.ToLower().Trim() == Productcode.ToLower().Trim());
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON"); 
                _db.Products.Update(obj);
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products OFF");
                _responseDto.Result = _mapper.Map<ProductDto>(obj);

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
                Product obj = _db.Products.First(x => x.ProductId == id);
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products ON"); 
                _db.Products.Remove(obj);
                _db.SaveChanges();
                //_db.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Products OFF");
                //_responseDto.Result = _mapper.Map<ProductDto>(obj);

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
