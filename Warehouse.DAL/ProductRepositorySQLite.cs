using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Contracts;
using Warehouse.Domain.Entities;

namespace Warehouse.DAL
{
    public class ProductRepositorySQLite : IProductRepository
    {
        public int AddNewProduct(Product product)
        {
            using (WarehouseDbContext db = new WarehouseDbContext())
            {
                db.Products.Add(product);
                db.SaveChanges();
                return product.Id;
            }
        }

        public bool DeleteProductByArticle(string article)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByArticle(string article)
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public int GetProductCount()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
