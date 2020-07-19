using MediatR;
using Narvan.Domains.Users.Entities;

namespace Narvan.Domains.Users.Queries
{
    public class GetUserByIdInfo:IRequest<User>
    {
        public long Id { get; set; }

        public GetUserByIdInfo(long id)
        {
            Id = id;
        }
    }
}