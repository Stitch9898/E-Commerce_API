using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //订单详情表
    public class order_detail
    {
        //订单详情表ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_detail_id { get; set; }
        //订单表ID
        public int order_id { get; set; }
        //订单商品ID
        public int product_id { get; set; }
        //商品名称
        public string product_name { get; set; }
        //购买商品数量
        public int product_cnt { get; set; }
        //购买商品单价
        public decimal product_price { get; set; }
    }
}
