using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Core
{
    public enum UnitOfMeasurement
    {
        None = 0,
        /// <summary>
        /// Штука
        /// </summary>
        Unit,
        Kg,
        Gr,
        Metre,
        Litre
    }
}
