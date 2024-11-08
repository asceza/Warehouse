using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Core;

namespace Warehouse.Domain.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public ProductCategory Category { get; set; }
        public float Amount { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string StoragePlace { get; set; } // xxx-xxx-xxx

        public Product(string name, ProductCategory productCategory)
        {
            Name = name;
            Category = productCategory;
        }


    }
}
