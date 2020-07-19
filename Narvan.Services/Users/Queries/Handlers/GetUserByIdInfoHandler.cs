using MediatR;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Queries;
using Narvan.Domains.Users.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Queries.Handlers
{
    public class GetUserByIdInfoHandler : IRequestHandler<GetUserByIdInfo, User>
    {
        private readonly IUserRepositoryQuery _query;

        public GetUserByIdInfoHandler(IUserRepositoryQuery query)
        {
            _query = query;
        }
        public async Task<User> Handle(GetUserByIdInfo request, CancellationToken cancellationToken)
        {
            return await _query.GetUserById(request.Id);
        }
    }
}