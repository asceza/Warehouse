using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Warehouse.Domain.Entities;

namespace Warehouse.Domain.Core
{
    //public class StoragePlace
    //{
    //    public string Data { get; private set; }

    //    const string pattern = @"^\d{3}-\d{3}-\d{3}"; // Маска xxx-xxx-xxx

    //    public StoragePlace(string data)
    //    {
    //        bool isStoragePlaceCorrect = Regex.IsMatch(data, pattern);
    //        if (isStoragePlaceCorrect)
    //        {
    //            Data = data;
    //        }
    //        else
    //        {
    //            throw new ArgumentException("Не верный формат StoragePlace");
    //        }
    //    }

    //}


    public class StoragePlace
    {
        private static Regex regex = new Regex(@"^\d{3}-\d{3}-\d{3}", RegexOptions.Compiled | RegexOptions.CultureInvariant);

        static bool CanAssing(string value)
        {
            bool isMatch = regex.IsMatch(value);
            return isMatch;
        }


        public string Data { get; init; }
        
        // Пустой конструктор для десериализации
        public StoragePlace() { }

        public StoragePlace(string value)
        {
            if (!CanAssing(value))
            {
                throw new ArgumentException("Invalid value format");
            }
            else
            {
                Data = value;
            }
        }
    }


}
