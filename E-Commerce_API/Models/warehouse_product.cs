using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //商品库存表
    public class warehouse_product
    {
        //商品库存ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wp_id { get; set; }
        //商品ID
        public int product_id { get; set; }
        //当前商品数量
        public int current_cnt { get; set; }
    }
}
