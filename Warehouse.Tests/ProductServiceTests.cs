using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.DAL;
using Warehouse.Domain.Entities;
using Warehouse.Domain.Services;

namespace Warehouse.Tests
{
    public class ProductServiceTests
    {
        [Test]
        public void AddNewProduct_ShouldReturnTrue()
        {
            // arrange
            var productRepository = new ProductRepositoryJSON();
            var productService = new ProductService(productRepository);
            var newProduct = new Product()
            {
                Name = "Продукт тестовый 1",
                Article = "111111",
                Category = Domain.Core.ProductCategory.Clothes,
                Amount = 111,
                UnitOfMeasurement = Domain.Core.UnitOfMeasurement.Thing,
                StoragePlace = "111-111-111"
            };

            // act
            var result = productService.AddNewProduct(newProduct);

            // assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AddNewProduct_ShouldReturnFalse()
        {
            // arrange
            var productRepository = new ProductRepositoryJSON();
            var productService = new ProductService(productRepository);
            var newProduct = new Product()
            {
                Name = "Продукт тестовый 1",
                Article = "111111",
                Category = Domain.Core.ProductCategory.Clothes,
                Amount = 111,
                UnitOfMeasurement = Domain.Core.UnitOfMeasurement.Thing,
                StoragePlace = "111-111-11"
            };

            // act
            var result = productService.AddNewProduct(newProduct);

            // assert
            Assert.IsFalse(result);
        }
    }
}
