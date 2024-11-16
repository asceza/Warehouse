using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Warehouse.API.Models;
using Warehouse.Domain.Contracts;
using Warehouse.Domain.Entities;

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
        /// <param name="newProduct">Данные нового продукта</param>
        /// <returns>Id нового товара</returns>
        [HttpPost]
        public ActionResult<int> AddNewProduct(CreateProductRequest newProduct)
        {
            var id = _productService.AddNewProduct(newProduct.ToProduct());
            if (id == - 1)
            {
                return BadRequest("Unable to add product (Невозможно добавить продукт)");
            }
            return Ok(id);
        }


        /// <summary>
        /// Получение списка всех продуктов
        /// </summary>
        /// <returns>Список продуктов</returns>
        [HttpGet]
        public ActionResult<IEnumerable<ProductResponse>> GetAllProducts()
        {
            List<Product> products = _productService.GetAllProducts();
            List<ProductResponse> productsResponse = new List<ProductResponse>();

            foreach (var product in products)
            {
                productsResponse.Add(product.ToProductResponse());
            }
            return Ok(products);
        }


        /// <summary>
        /// Получение конкретного продукта по ID
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound($"Product with id = {id} not found (Продукт с id = {id} не найден)");
            }
            return Ok(product.ToProductResponse());
        }


        /// <summary>
        /// Удаление продукта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteProductById(int id)
        {
            bool isProductDeleted = _productService.DeleteProductById(id);
            if (!isProductDeleted)
            {
                return NotFound("Product not found (Продукт не найден)");
            }
            return Ok(isProductDeleted);
        }
    }



}
