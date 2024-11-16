using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            var products = _productRepository.GetAllProducts();
            return products;
        }

        private bool IsStoragePlaceCorrect(string storagePlace)
        {
            string pattern = @"^\d{3}-\d{3}-\d{3}"; // Маска xxx-xxx-xxx
            bool isStoragePlaceCorrect = Regex.IsMatch(storagePlace, pattern);
            return isStoragePlaceCorrect;
        }



        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product;
        }

        public int DeleteProductById(int id)
        {
            int numberDeletedElement = _productRepository.DeleteProductById(id);
            return numberDeletedElement;
        }
    }
}
