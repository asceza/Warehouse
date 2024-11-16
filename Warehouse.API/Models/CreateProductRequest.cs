using Warehouse.Domain.Core;

namespace Warehouse.Domain.Contracts
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public ProductCategory Category { get; set; }
        public float Amount { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public string StoragePlace { get; set; } // xxx-xxx-xxx
    }



}
