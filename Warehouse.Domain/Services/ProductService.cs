using System.Collections.Generic;
using System.Text.RegularExpressions;
using Warehouse.Domain.Contracts;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        /// <summary>
        /// Добавление нового продукта
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns>Id нового продукта</returns>
        public int AddNewProduct(Product newProduct)
        {
            int id = _productRepository.AddNewProduct(newProduct);
            return id;
            //newProduct.ID = IncrementProductId();
            //bool isStoragePlaceCorrect = IsStoragePlaceCorrect(newProduct.StoragePlace);
            //if (isStoragePlaceCorrect)
            //{
            //    var isProductAdded = _productRepository.AddNewProduct(newProduct);
            //    return isProductAdded;
            //}
            //else
            //{
            //    return false;
            //}
        }


        public List<Product> GetAllProducts()
        {
            List<Product> products = _productRepository.GetAllProducts();
            return products;
        }

        //private bool IsStoragePlaceCorrect(string storagePlace)
        //{
        //    string pattern = @"^\d{3}-\d{3}-\d{3}"; // Маска xxx-xxx-xxx
        //    bool isStoragePlaceCorrect = Regex.IsMatch(storagePlace, pattern);
        //    return isStoragePlaceCorrect;
        //}



        public Product GetProductById(int id)
        {
            Product product = _productRepository.GetProductById(id);
            return product;
        }

        /// <summary>
        /// Удаление продукта по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Успешность удаления</returns>
        public bool DeleteProductById(int id)
        {
            bool isProductDeleted = _productRepository.DeleteProductById(id);
            return isProductDeleted;
        }
    }
}
