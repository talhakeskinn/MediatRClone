using MediatrClone.API.Models;
using MediatrClone.Library.Interfaces;

namespace MediatrClone.API.Queries
{
    public class GetUserByIdQuery : IRequest<UserViewModel>
    {
        public int Id { get; init; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        public Task<UserViewModel> Handle(GetUserByIdQuery request)
        {
            return Task.FromResult(new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe"
            });
        }
    }
}
