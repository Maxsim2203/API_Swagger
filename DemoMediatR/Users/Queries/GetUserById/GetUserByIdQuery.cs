using MediatR;

namespace DemoMediatR.Users.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResult>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id) => Id = id;
    }
}
