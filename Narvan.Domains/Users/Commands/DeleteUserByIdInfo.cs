using MediatR;
using Narvan.Domains.Enums;

namespace Narvan.Domains.Users.Commands
{
    public class DeleteUserByIdInfo:IRequest<ResultStatusType>
    {
        public long Id { get; set; }

        public DeleteUserByIdInfo(long id)
        {
            Id = id;
        }
        
    }
}