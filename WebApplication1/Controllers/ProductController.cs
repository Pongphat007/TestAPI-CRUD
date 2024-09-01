using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<ProductList> _ProductList = new List<ProductList>();

        [HttpPost]
        [Route("api/CreateProductList")]
        public IActionResult CreateProductList([FromBody] ProductList data)
        {
            data.id = _ProductList.Count + 1;
            _ProductList.Add(data);

            return Ok(_ProductList);
        }

        [HttpGet]
        [Route("api/GetAllProductList")]
        public IActionResult GetAllProductList()
        {
            return Ok(_ProductList);
        }

        [HttpPut]
        [Route("api/UpdateProductById")]
        public IActionResult UpdateProductById([FromBody] ProductList data)
        {
            try
            {
                if(!string.IsNullOrEmpty(data.id.ToString()))
                {
                    var product = _ProductList.FirstOrDefault(p => p.id == data.id);
                    if(product != null)
                    {
                        product.name = data.name;  
                        product.description = data.description;
                        product.Price = data.Price;

                        return Ok(_ProductList);
                    }
                    else
                    {
                        throw new Exception("Not found id");
                    }
                    
                }
                else
                {
                    throw new Exception("Not found id");
                }
            }
            catch (Exception ex)
            {

               return BadRequest(ex);
            }
          
        }
    }
}
