using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Warehouse.DAL;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Services;
using Warehouse.Domain.Services.Abstract;
using Warehouse.WebUI.Models;
using Warehouse.WebUI.Services;

namespace Warehouse.WebUI.Controllers
{

    [Route("api/[controller]")] // /api/product
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            var productRepository = new ProductRepositoryJSON();
            _productService = new ProductService(productRepository);
        }


        [HttpPost]
        public ActionResult<bool> AddNewProduct(Product newProduct)
        {
            var result = _productService.AddNewProduct(newProduct);
            if (!result)
            {
                return BadRequest("Unable to add product (Невозможно добавить продукт)");
            }
            return Ok(result);
        }

        /*
        // Метод для получения списка всех продуктов
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        // Метод для удаления продукта
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result)
            {
                return NotFound("Product not found.");
            }
            return Ok(result);
        }

        // Метод для получения конкретного продукта по ID
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        */
    }



}
