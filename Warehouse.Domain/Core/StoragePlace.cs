using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Core
{
    public class StoragePlace
    {
        public string Data { get; private set; }

        const string pattern = @"^\d{3}-\d{3}-\d{3}"; // Маска xxx-xxx-xxx

        public bool IsStoragePlaceCorrect { get; private set; }
        public StoragePlace(string data)
        {
            bool isStoragePlaceCorrect = Regex.IsMatch(data, pattern);
            if (isStoragePlaceCorrect)
            {
                Data = data;
                IsStoragePlaceCorrect = true;
            }
            else
            {
                throw new ArgumentException("Не верный формат StoragePlace");
            }
        }

    }
}
