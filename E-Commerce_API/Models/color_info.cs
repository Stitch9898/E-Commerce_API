using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //颜色表
    public class color_info
    {
        //主键
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int color_id { get; set; }
        //颜色名字
        public string color_name { get; set; }

    }
}
