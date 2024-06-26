﻿using Mango.Web.Models.Dto.Product;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mango.Web.Models.Dto.Cart
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto? CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductDto? Product { get; set; }
        public int Count { get; set; }
    }
}
