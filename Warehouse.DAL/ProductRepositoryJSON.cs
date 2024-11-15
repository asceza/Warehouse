﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool AddNewProduct(Product product)
        {
            List<Product> products = GetAllProducts();
            products.Add(product);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(products));

            var foundedProduct = GetProductById(product.ID);
            if (foundedProduct == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int DeleteProductByArticle(string article)
        {
            throw new NotImplementedException();
        }

        public int DeleteProductById(int id)
        {
            List<Product> products = GetAllProducts();
            int numberDeletedElement = products.RemoveAll(p => p.ID == id);
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(products));
            return numberDeletedElement;
        }

        public List<Product> GetAllProducts()
        {
            if (!File.Exists(_filePath))
            {
                //System.IO.File.Create(_filePath);
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
            var selectProduct = (Product)products.FirstOrDefault(p => p.ID == id);
            return selectProduct;
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
