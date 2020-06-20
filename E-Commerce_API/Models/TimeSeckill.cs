using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_API.Models
{
    public class TimeSeckill
    {
        //订单详情表ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int seckill_id { get; set; }
        public int product_id { get; set; }
        public int is_seckill { get; set; }
        public string start_seckillTime { get; set; }
        public string end_seckillTime { get; set; }
    }
}
