using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //购物车表
    public class order_cart
    {
        //购物车ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cart_id { get; set; }
        //用户ID
        public int customer_id { get; set; }
        //商品ID
        public int product_id { get; set; }
        //加入购物车商品数量
        public int product_amount { get; set; }
        //商品价格
        public decimal price { get; set; }
        //加入购物车时间
        public string add_time { get; set; }
    }
}
