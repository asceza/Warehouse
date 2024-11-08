using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Services.Abstract
{
    public interface IProductService
    {
        public List<Product> GetAllProduct();
    }
}
