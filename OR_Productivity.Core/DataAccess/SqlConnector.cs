using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OR_Productivity.Core.Models;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace OR_Productivity.Core.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        static string conString = GlobalConfig.CnnString("SVH-SQL2");
        public IEnumerable<ORProduct> GetOrProduct(string dateFrom, string dateTo)
        {
            var models = new List<ORProduct>();
            using (IDbConnection db = new SqlConnection(conString))
            {
                models = db.Query<ORProduct>(DbQuery.GetORProductivity(), new { dateFrom = dateFrom, dateTo = dateTo }).ToList();
            }

            return models;
        }
    }
}
