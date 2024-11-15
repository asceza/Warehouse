using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Contracts
{
    public interface IProductService
    {
        public List<Product> GetAllProducts();
        public bool AddNewProduct(Product product);
        public Product GetProductById(int id);
        public int DeleteProductById(int id);
    }
}
