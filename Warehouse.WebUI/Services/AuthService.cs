using System;
using System.Collections.Generic;

namespace Warehouse.WebUI.Services
{
    public class AuthService
    {
        public List<string> Employees { get; private set; }

        public AuthService()
        {
            Employees = new List<string>
            {
                "Иванов",
                "Петров",
                "Сидоров"
            };
        }

        public bool Login(string lastName)
        {
            if(string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return Employees.Contains(lastName);
        }
    }
}
