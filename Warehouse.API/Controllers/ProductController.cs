using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Warehouse.DAL;
using Warehouse.Domain.Contracts;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Services;
using Warehouse.WebAPI.Models;
using Warehouse.WebAPI.Services;

namespace Warehouse.WebAPI.Controllers
{

    [Route("api/[controller]")] // /api/product
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Добавление нового продукта
        /// </summary>
        /// <param name="newProduct">Данные нового продукта.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Получение списка всех продуктов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        /// <summary>
        /// Получение конкретного продукта по ID
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound("Product not found (Продукт не найден)");
            }
            return Ok(product);
        }

        /// <summary>
        /// Удаление конкретного продукта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteProductById(int id)
        {
            var numberDeletedElement = _productService.DeleteProductById(id);
            if (numberDeletedElement < 1)
            {
                return NotFound("Product not found (Продукт не найден)");
            }
            return Ok(numberDeletedElement);
        }
    }



}
