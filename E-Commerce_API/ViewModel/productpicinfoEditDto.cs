using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace E_Commerce_API.ViewModel
{
    public class productpicinfoEditDto
    {
        public int product_id { get; set; }
        //商品编码(流水号)
        public string product_core { get; set; }
        //商品名称
        public string product_name { get; set; }
        //品牌
        public string brand_name { get; set; }
        //商品销售价格
        public decimal price { get; set; }
        //上下架状态：0下架1上架
        public int publish_status { get; set; }
        //商品重量
        public float weight { get; set; }
        //商品长度
        public float length { get; set; }
        //商品高度
        public float height { get; set; }
        //商品宽度
        public float width { get; set; }
        //颜色
        public int color_type { get; set; }
        //商品录入时间
        public string indate { get; set; }
        //商品描述
        public string descript { get; set; }
        public IFormFile product_formfile { get; set; }
        //当前商品数量
        public int current_cnt { get; set; }
    }
}
