using Warehouse.Domain.Core;

namespace Warehouse.API.Models
{
    public class ProductResponse
    {
        public int ID { get; set; }
        //public int ID { get; private set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public ProductCategory Category { get; set; }
        public float Amount { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string StoragePlace { get; set; } // xxx-xxx-xxx
    }
}
