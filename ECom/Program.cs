using System;
using ECom;

namespace ECom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Redis写入缓存：wuchengtest"); //添加

            DbHelper.Add("wuchen", "jiwuchen", DateTime.Now.AddDays(1));
             
            Console.WriteLine("Redis获取缓存：crtest666");//查找
                                                     // string str3 = RedisCacheHelper.Get<string>("crtest666");
                                                     // Console.WriteLine(str3);

            DbHelper.Remove("hellow");//删除
            string str = DbHelper.Get<string>("hellow");//查看是否删除成功
            Console.WriteLine(str == null ? "未找到" : str);
            Console.ReadKey();
        }
    }
}
