using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OR_Productivity.Core.Models;

namespace OR_Productivity.Core.DataAccess
{
    public interface IDataConnection
    {
        IEnumerable<ORProduct> GetOrProduct(string dateFrom, string dateTo);
    }
}
