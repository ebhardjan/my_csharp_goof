using System;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MediatR;

namespace 004_MediatR {
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, User>
    {
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            using (var conn = new SqlConnection("connString"))
            {
                var query = "SELECT * FROM Users WHERE UserID = " + request.Id;
                var command = new SqlCommand(query, conn);
                command.ExecuteReader();
            }
            return null;
        }
    }
}
