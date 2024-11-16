using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.API.Models;
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
                return new Product
                {
                    Name = product.Name,
                    Article = product.Article,
                    Category = product.Category,
                    Amount = product.Amount,
                    UnitOfMeasurement = product.UnitOfMeasurement,
                    StoragePlace = product.StoragePlace,
                };
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
                    ID = product.ID,
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
