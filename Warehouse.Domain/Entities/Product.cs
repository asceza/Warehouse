using Warehouse.Domain.Core;

namespace Warehouse.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        //public int ID { get; private set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public ProductCategory Category { get; set; }
        public float Amount { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; private set; }
        public StoragePlace StoragePlace { get; set; }



        public Product(UnitOfMeasurement unitOfMeasurement)
        {
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}


         