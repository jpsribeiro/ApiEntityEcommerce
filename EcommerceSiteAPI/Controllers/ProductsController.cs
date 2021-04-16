using EcommerceSiteAPI.Models;
using EcommerceSiteAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSiteAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContent _ecommerceDbContent;
        public ProductsController(EcommerceDbContent ecommerceDbContent) 
        {
            _ecommerceDbContent = ecommerceDbContent;
        }

        //api/products HTTP GET
        [HttpGet]
        public IActionResult get()
        {
            var products = _ecommerceDbContent.Products.ToList();

            return Ok(products);
        }

        //api/products/:id HTTP GET
        [HttpGet("{id}")]
        public IActionResult GetbyId(int id)
        {
            var product = _ecommerceDbContent.Products.SingleOrDefault(x => x.ID == id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductInputModel productInputModel) 
        {
            if (productInputModel == null) 
            {
                return BadRequest();
            }

            var product = new Products(productInputModel.Description, productInputModel.Price);

            _ecommerceDbContent.Products.Add(product);
            _ecommerceDbContent.SaveChanges();

            return CreatedAtAction(nameof(GetbyId), new { id = product.ID }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductInputModel productInputModel, int id)
        {
            if (productInputModel == null) 
            {
                return BadRequest();
            }

            var product = _ecommerceDbContent.Products.SingleOrDefault(x => x.ID == id);

            if (product == null) 
            {
                return NotFound();
            }

            product.Description = productInputModel.Description;
            product.Price = productInputModel.Price;

            _ecommerceDbContent.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var product = _ecommerceDbContent.Products.SingleOrDefault(x => x.ID == id);

            if (product == null) 
            {
                return NotFound();
            }

            _ecommerceDbContent.Products.Remove(product);

            _ecommerceDbContent.SaveChanges();

            return NoContent();
        }

    }
}
