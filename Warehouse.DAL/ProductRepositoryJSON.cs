using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Warehouse.Domain.Contracts;
using Warehouse.Domain.Entities;

namespace Warehouse.DAL
{
    public class ProductRepositoryJSON : IProductRepository
    {
        private readonly string _filePath;

        public ProductRepositoryJSON(string filePath = "products.json")
        {
            _filePath = filePath;
        }


        /// <summary>
        /// Добавление нового товара
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Id нового продукта</returns>
        public int AddNewProduct(Product product)
        {
            List<Product> products = GetAllProducts();
            product.Id = GetProductCount() + 1;
            products.Add(product);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(products));

            var foundedProduct = GetProductById(product.Id);
            if (foundedProduct == null)
            {
                return -1;
            }
            else
            {
                return product.Id;
            }
        }


        /// <summary>
        /// Получение счетчика товаров
        /// </summary>
        /// <returns>Максимальный Id</returns>
        public int GetProductCount()
        {
            var products = GetAllProducts();

            if (products.Count == 0)
            {
                return 1;
            }
            else
            {
                int id = products.Max(k => k.Id);
                return id;
            }
        }


        public bool DeleteProductByArticle(string article)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Удаление продукта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Успешность удаления</returns>
        public bool DeleteProductById(int id)
        {
            List<Product> products = GetAllProducts();
            int numberDeletedElement = products.RemoveAll(p => p.Id == id);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(products));
            return numberDeletedElement > 0 ? true : false;
        }


        public List<Product> GetAllProducts()
        {
            if (!File.Exists(_filePath))
            {
                System.IO.File.Create(_filePath);
                return new List<Product>();
            }

            string stringFromFile = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Product>>(stringFromFile) ?? new List<Product>();
        }


        public Product GetProductByArticle(string article)
        {
            throw new NotImplementedException();
        }


        public Product GetProductById(int id)
        {
            var products = GetAllProducts();
            var selectProduct = (Product)products.FirstOrDefault(p => p.Id == id);
            return selectProduct;
        }


        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
