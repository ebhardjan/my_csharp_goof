using Autofac;
using System.Web;

namespace SqlInjection_001_Autofac
{
    public class Handler : IHttpHandler
    {
        private IContainer Container;

        public Handler()
        {
          var builder = new ContainerBuilder();
          builder.RegisterType<QueryExecutor>().As<IQueryExecutor>();
          Container = builder.Build();
        }

        public void ProcessRequest(HttpContext context)
        {
            string queryParam = HttpContext.Current.Request.Form["queryParam"];

            var sqlString = "SELECT * FROM Products WHERE CategoryID = " + queryParam;
            using (var scope = Container.BeginLifetimeScope())
            {
              scope.Resolve<IQueryExecutor>().ExecuteThisQuery(sqlString);
            }
        }
    }
}
