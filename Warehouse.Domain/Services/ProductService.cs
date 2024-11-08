using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<Product> GetAllProduct()
        {
            var products = _productRepository.GetAllProducts();
            return products;
        }
    }
}
