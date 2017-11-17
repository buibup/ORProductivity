using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OR_Productivity.Core.DataAccess
{
    public static class DbQuery
    {
        public static string GetORProductivity()
        {
            const string dbQuery = "select * from [dbo].[OR_Productivity] Where date_add >= @DateFrom and date_add <= @DateTo";
            return dbQuery;
        }
    }
}
