using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Warehouse.DAL.Abstract;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Services.Abstract;

namespace Warehouse.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return products;
        }

        public bool AddNewProduct(Product newProduct)
        {
            newProduct.ID = IncrementProductId();
            bool isStoragePlaceCorrect = IsStoragePlaceCorrect(newProduct.StoragePlace);
            if (isStoragePlaceCorrect)
            {
                var isProductAdded = _productRepository.AddNewProduct(newProduct);
                return isProductAdded;
            }
            else
            {
                return false;
            }
        }

        private bool IsStoragePlaceCorrect(string storagePlace)
        {
            string pattern = @"^\d{3}-\d{3}-\d{3}"; // Маска xxx-xxx-xxx
            bool isStoragePlaceCorrect = Regex.IsMatch(storagePlace, pattern);
            return isStoragePlaceCorrect;
        }

        private int IncrementProductId()
        {
            var products = GetAllProducts();

            if (products.Count == 0)
            {
                return 1;
            }
            else
            {
                int ID = products.Max(k => k.ID + 1);
                return ID;
            }
        }

        public Product GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            return product;
        }
    }
}
