using System;
using System.Data.SqlClient;

namespace SqlInjection_001_Autofac
{
  public interface IQueryExecutor
  {
    void ExecuteThisQuery(string sqlQuery);
  }

  public class QueryExecutor : IQueryExecutor
  {
    void ExecuteThisQuery(string sqlQuery) {
    {
        using (var conn = new SqlConnection("connString"))
        {
            var command = new SqlCommand(sqlQuery, conn);
            command.ExecuteReader();
        }
    }
  }

}