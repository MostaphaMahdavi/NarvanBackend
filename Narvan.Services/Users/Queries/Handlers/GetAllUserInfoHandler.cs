using AutoMapper;
using MediatR;
using Narvan.Domains.Users.Entities;
using Narvan.Domains.Users.Queries;
using Narvan.Domains.Users.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Narvan.Services.Users.Queries.Handlers
{

    public class GetAllUserInfoHandler : IRequestHandler<GetAllUserInfo, List<User>>
    {
        private readonly IUserRepositoryQuery _query;

        public GetAllUserInfoHandler(IUserRepositoryQuery query)
        {
            _query = query;
         
        }

        public async Task<List<User>> Handle(GetAllUserInfo request, CancellationToken cancellationToken)
        {
            return await _query.GetAllUser();
            
           
        }
    }
}