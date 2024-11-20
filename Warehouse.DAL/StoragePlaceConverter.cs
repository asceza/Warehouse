using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Domain.Core;

namespace Warehouse.DAL
{
    public static class StoragePlaceConverter
    {
        public static StoragePlace ToStoragePlace(string value)
        {
            return new StoragePlace { Data = value };
        }
    }
}
