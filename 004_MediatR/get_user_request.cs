using MediatR;
namespace 004_MediatR
{
    public class GetUserQuery : IRequest<User>
    {
        public GetUserQuery(string id) {
            Id = id;
        }
        public string Id {get;}
    }
}
