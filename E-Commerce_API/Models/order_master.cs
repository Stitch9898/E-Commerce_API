using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //订单主表
    public class order_master
    {
        //订单ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_id { get; set; }
        //订单编号 (流水号)
        public string order_sn { get; set; }
        //下单人ID
        public int customer_id { get; set; }
        //支付方式：1现金，2余额，3网银，4支付宝，5微信
        public int payment_method { get; set; }
        //订单金额
        public decimal order_money { get; set; }
        //下单时间
        public string create_time { get; set; }
    }
}
