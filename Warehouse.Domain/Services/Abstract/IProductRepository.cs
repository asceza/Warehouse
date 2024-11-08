using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.DAL.Abstract
{
    public interface IProductRepository
    {
        public void AddNewProduct(Product product);
        //void UpdateProduct(ProductEntity product);
        public Product GetProductByArticle(string article);
        public int DeleteProductById(int id);

        /// <summary>
        /// </summary>
        /// <param name="article"></param>
        /// <returns>Количество удаленных элементов</returns>
        public int DeleteProductByArticle(string article);
        public List<Product> GetAllProducts();

        public void UpdateProduct(Product product);
    }
}
