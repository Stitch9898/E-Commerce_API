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
        /// 添加是否秒杀
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("IsSeckill")]
        public async Task<ActionResult<int>> IsSeckill([FromBody]TimeSeckill seckill)
        {
            db.TimeSeckill.Add(seckill);
            return await db.SaveChangesAsync();
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
                await picCreate.product_formfile.CopyToAsync(stream);
            }

            productpicinfo productpicinfo = new productpicinfo
            {
                product_id = picCreate.product_id,
                //http/https  +   ://     +   域名端口   +  文件夹路径
                pic_url = Request.Scheme + "://" + Request.Host + "/ProductImgs/" + picCreate.product_formfile.FileName
            };

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
        /// <summary>
        /// 显示所有商品信息
        /// </summary>
        /// <param name="product_name"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetEmpAll")]
        public async Task<ActionResult<IEnumerable<ShowProduct>>> GetEmpAll(string product_name, int pageIndex, int pageSize)
        {
            var linq = (from s in db.warehouse_product
                        join m in db.product_info on s.product_id equals m.product_id
                        join d in db.productpicinfo on m.product_id equals d.product_id
                        join v in db.color_info on m.color_type equals v.color_id
                        join k in db.TimeSeckill on m.product_id equals k.product_id
                        select new ShowProduct
                        {
                            product_id = m.product_id,
                            product_core = m.product_core,
                            product_name = m.product_name,
                            brand_name = m.brand_name,
                            price = m.price,
                            publish_status = m.publish_status,
                            weight = m.weight,
                            length = m.length,
                            height = m.height,
                            width = m.width,
                            color_type = m.color_type,
                            indate = m.indate,
                            descript = m.descript,
                            color_id = v.color_id,
                            color_name = v.color_name,
                            is_seckill = k.is_seckill,
                            start_seckillTime = k.start_seckillTime,
                            end_seckillTime = k.end_seckillTime,
                            pic_url = d.pic_url,
                            current_cnt = s.current_cnt,
                        });
            IQueryable<ShowProduct> str;
            //name=x
            if (product_name != null)
            {
                str = linq.Where(m => m.product_name.Contains(product_name));
                return await str.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            else
            {
                return await linq.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            }
        }
        /// <summary>
        /// 显示商品和查询商品名称
        /// </summary>
        /// <param name="product_name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPages")]
        public int GetPages(string product_name)
        {

            var linq = (from s in db.warehouse_product
                        join m in db.product_info on s.product_id equals m.product_id
                        join d in db.productpicinfo on m.product_id equals d.product_id
                        join v in db.color_info on m.color_type equals v.color_id
                        join k in db.TimeSeckill on m.product_id equals k.product_id
                        select new ShowProduct
                        {
                            product_id = m.product_id,
                            product_core = m.product_core,
                            product_name = m.product_name,
                            brand_name = m.brand_name,
                            price = m.price,
                            publish_status = m.publish_status,
                            weight = m.weight,
                            length = m.length,
                            height = m.height,
                            width = m.width,
                            color_type = m.color_type,
                            indate = m.indate,
                            descript = m.descript,
                            color_id = v.color_id,
                            color_name = v.color_name,
                            pic_url = d.pic_url,
                            current_cnt = s.current_cnt,
                            is_seckill = k.is_seckill,
                            start_seckillTime = k.start_seckillTime,
                            end_seckillTime = k.end_seckillTime,
                        });
            int str;
            //name=x             descript                     descript    
            if (product_name != null)
            {
                str = linq.Where(m => m.product_name.Contains(product_name)).Count();
                return str;
            }
            else
            {
                return linq.Count();
            }
        }
        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteProduct")]
        public async Task<ActionResult<int>> DeleteProduct(int Id)
        {
            db.product_info.Remove(db.product_info.FirstOrDefault(m => m.product_id == Id));
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 删除库存信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Deletewarehouse")]
        public async Task<ActionResult<int>> Deletewarehouse(int Id)
        {
            db.warehouse_product.Remove(db.warehouse_product.FirstOrDefault(m => m.product_id == Id));
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 删除库存信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("Deleteproductpicinfo")]
        public async Task<ActionResult<int>> Deleteproductpicinfo(int Id)
        {
            db.productpicinfo.Remove(db.productpicinfo.FirstOrDefault(m => m.product_id == Id));
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 反填商品信息
        /// </summary>
        /// <returns></returns>
        [Route("Getstorage")]
        public async Task<ActionResult<product_info>> Revise(int id)
        {
            return await db.product_info.AsNoTracking().FirstOrDefaultAsync(m => m.product_id.Equals(id));
        }
        /// <summary>
        /// 反填图片
        /// </summary>
        /// <returns></returns>
        [Route("Getproductpicinfo")]
        public async Task<ActionResult<productpicinfo>> Getproductpicinfo(int id)
        {
            return await db.productpicinfo.AsNoTracking().FirstOrDefaultAsync(m => m.product_id.Equals(id));
        }
        /// <summary>
        /// 反填库存
        /// </summary>
        /// <returns></returns>
        [Route("Getwarehouse_product")]
        public async Task<ActionResult<warehouse_product>> Getwarehouse_product(int id)
        {
            return await db.warehouse_product.AsNoTracking().FirstOrDefaultAsync(m => m.product_id.Equals(id));
        }
        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <returns></returns>
        [Route("Revisestorage")]
        public async Task<ActionResult<int>> Revisestorage([FromBody]product_info product)
        {
            db.Entry(product).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 修改是否秒杀
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("AlertTimeSeckill")]
        public async Task<ActionResult<int>> AlertTimeSeckill([FromBody]TimeSeckill seckill)
        {
            seckill.is_seckill = 1;
            db.TimeSeckill.Attach(seckill);
            db.Entry(seckill).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }



        [HttpPut("edit/{product_id}")]
        public async Task<IActionResult> Edit(int product_id, [FromForm]productpicinfoEditDto editDto)
        {

            var product_Info = await db.product_info.FindAsync(product_id);


            product_Info.product_name = editDto.product_name;
            product_Info.brand_name = editDto.brand_name;
            product_Info.price = editDto.price;
            product_Info.publish_status = editDto.publish_status;
            product_Info.weight = editDto.weight;
            product_Info.length = editDto.length;
            product_Info.height = editDto.height;
            product_Info.width = editDto.width;
            product_Info.color_type = editDto.color_type;
            product_Info.descript = editDto.descript;

            db.product_info.Update(product_Info);



            //图片不为空在修改
            if (editDto.product_formfile != null)
            {
                var productpicinfo = await db.productpicinfo.FirstOrDefaultAsync(m => m.product_id == product_id);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImgs", editDto.product_formfile.FileName);

                using (var stream = System.IO.File.Create(path))
                {
                    await editDto.product_formfile.CopyToAsync(stream);
                }


                productpicinfo.pic_url = Request.Scheme + "://" + Request.Host + "/ProductImgs/" + editDto.product_formfile.FileName;


                db.productpicinfo.Update(productpicinfo);
            }


            var warehouse_Product = await db.warehouse_product.FirstOrDefaultAsync(m => m.product_id == product_id);

            warehouse_Product.current_cnt = editDto.current_cnt;
            db.warehouse_product.Update(warehouse_Product);



            return Ok(await db.SaveChangesAsync());
        }


        /// <summary>
        /// 修改图片
        /// </summary>
        /// <returns></returns>
        [Route("Reviseproductpicinfo")]
        public async Task<ActionResult<int>> Reviseproductpicinfo([FromBody]productpicinfo product)
        {
            db.Entry(product).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 修改库存
        /// </summary>
        /// <returns></returns>
        [Route("Revisewarehouse_product")]
        public async Task<ActionResult<int>> Revisewarehouse_product([FromBody]warehouse_product product)
        {
            db.Entry(product).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
    }
}