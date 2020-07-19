using Narvan.Domains.Users.Repositories;
using System.Threading.Tasks;

namespace Narvan.Domains.Commons
{
    public interface IUnitOfWork
    {
        IUserRepositoryCommand UserRepositoryCommand { get; }


        Task Save();
    }
}