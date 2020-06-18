using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_API.ViewModel
{
    public class productpicinfoCreateDto
    {
        //商品ID
        public int product_id { get; set; }
        //图片URL（表单文件）
        public IFormFile product_formfile { get; set; }
    }
}
