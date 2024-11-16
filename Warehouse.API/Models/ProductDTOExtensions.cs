using System;
using System.Xml.Linq;
using Warehouse.API.Models;
using Warehouse.Domain.Core;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Contracts
{
    public static class ProductDTOExtensions
    {
        public static Product ToProduct(this CreateProductRequest product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                Product newProduct = new Product(product.UnitOfMeasurement);
                newProduct.Name = product.Name;
                newProduct.Article = product.Article;
                newProduct.Category = product.Category;
                newProduct.Amount = product.Amount;
                newProduct.StoragePlace = product.StoragePlace;

                return newProduct;
            }
        }

        public static ProductResponse ToProductResponse(this Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            else
            {
                return new ProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Article = product.Article,
                    Category = product.Category,
                    Amount = product.Amount,
                    UnitOfMeasurement = product.UnitOfMeasurement,
                    StoragePlace = product.StoragePlace,
                };
            }
        }
    }
}
