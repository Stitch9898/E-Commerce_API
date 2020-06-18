using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //用户信息表
    public class customer_inf
    {
        //自增主键ID
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customer_inf_id { get; set; }
        //customer_login表的自增ID
        public int customer_id { get; set; }
        //用户真实姓名
        public string customer_name { get; set; }
        //证件类型
        public int identity_card_type { get; set; }
        //证件号码
        public string identity_card_no { get; set; }
        //手机号
        public string mobile_phone { get; set; }
        //性别
        public int gender { get; set; }
        //用户余额
        public decimal user_money { get; set; }
        //地址
        public string address { get; set; }
        //注册时间
        public string register_time { get; set; }
    }
}
