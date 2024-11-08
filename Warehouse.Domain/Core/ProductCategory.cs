using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Core
{
    public enum ProductCategory
    {
        None,
        /// <summary>
        /// Жидкость
        /// </summary>
        Liquid,
        /// <summary>
        /// Крепеж
        /// </summary>
        Fasteners,
        /// <summary>
        /// Полуфабрикат
        /// </summary>
        Semi_finished,
        /// <summary>
        /// Инструмент
        /// </summary>
        Tool,
        /// <summary>
        /// Мебель
        /// </summary>
        Furniture,
        /// <summary>
        /// Одежда
        /// </summary>
        Clothes
    }
}
