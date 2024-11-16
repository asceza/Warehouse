using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Core;
using Warehouse.Domain.Entities;

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
