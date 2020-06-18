using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Shop_API.Models
{
    //用户登录表
    public class customer_login
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //用户ID
        public int customer_id { get; set; }
        //用户登录名
        public string login_name { get; set; }
        //md5加密的密码
        public string password { get; set; }
        //用户状态 0 不可用(无法登陆) 1(可以登录)
        public int user_stats { get; set; }
    }
}
