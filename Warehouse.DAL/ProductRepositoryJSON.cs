﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL.Abstract;
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

        public void AddNewProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public int DeleteProductByArticle(string article)
        {
            throw new NotImplementedException();
        }

        public int DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            //List<Product> products = new List<Product>
            //{
            //    new Product("Продукт_1", Domain.Core.ProductCategory.Fasteners),
            //    new Product("Продукт_2", Domain.Core.ProductCategory.Clothes),
            //    new Product("Продукт_3", Domain.Core.ProductCategory.Liquid)
            //};
            //return products;

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

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
