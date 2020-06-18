using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //商品图片表
    public class productpicinfo
    {
        //商品图片ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int product_pic_id { get; set; }
        //商品ID
        public int product_id { get; set; }
        //图片URL
        public string pic_url { get; set; }
    }
}
