using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication_Shop_API.Models;
using System.Linq;
using E_Commerce_API.ViewModel;
using System.IO;

namespace E_Commerce_API.Controllers
{
    //[Produces("application/json", "application/xml")]
    //改变响应格式
    [Route("api/[controller]")]
    // [ApiController]
    [EnableCors("cors")]//设置跨域处理的代理
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public EC_Context db;
        public CustomerController(EC_Context db) { this.db = db; }
        /// <summary>
        /// 添加用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCustomer_inf")]
        public async Task<ActionResult<int>> AddCustomer_inf([FromBody]customer_inf customer)
        {
            db.customer_inf.Add(customer);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 添加颜色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddColor_info")]
        public async Task<ActionResult<int>> AddColor_info([FromBody]color_info color)
        {
            db.color_info.Add(color);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 显示颜色
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowColor_info")]
        public async Task<ActionResult<IEnumerable<color_info>>> ShowColor_info()
        {
            return await db.color_info.ToListAsync();
        }
        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProduct_info")]
        public async Task<ActionResult<int>> AddProduct_info([FromBody]product_info product)
        {
            db.product_info.Add(product);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 显示商品信息
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowProduct_info")]
        public async Task<ActionResult<IEnumerable<product_info>>> ShowProduct_info()
        {
            return await db.product_info.ToListAsync();
        }
        /// <summary>
        /// 添加商品图片
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddProductpicinfo")]
        public async Task<ActionResult<int>> AddProductpicinfo([FromForm]productpicinfoCreateDto picCreate)
        {

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImgs", picCreate.product_formfile.FileName);

            using (var stream = System.IO.File.Create(path))
            {
              await  picCreate.product_formfile.CopyToAsync(stream); 
            }

            productpicinfo productpicinfo = new productpicinfo { 
                product_id = picCreate.product_id,
                //http/https  +   ://     +   域名端口   +  文件夹路径
                pic_url =Request.Scheme +"://"+Request.Host+ "/ProductImgs/"+ picCreate.product_formfile.FileName };

                db.productpicinfo.Add(productpicinfo);
                return await db.SaveChangesAsync(); 
        }
        
        /// <summary>
        /// 添加商品库存
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddWarehouse_product")]
        public async Task<ActionResult<int>> AddWarehouse_product([FromBody]warehouse_product warehouse)
        {
            db.warehouse_product.Add(warehouse);
            return await db.SaveChangesAsync();
        }
    }
}