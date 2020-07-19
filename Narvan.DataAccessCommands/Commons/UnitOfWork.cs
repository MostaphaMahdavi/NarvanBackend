using Narvan.DataAccessCommands.Context;
using Narvan.DataAccessCommands.Users.Repositories;
using Narvan.Domains.Commons;
using Narvan.Domains.Users.Repositories;
using System.Threading.Tasks;

namespace Narvan.DataAccessCommands.Commons
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NarvanContext _context;


        public UnitOfWork(NarvanContext context)
        {
            _context = context;
            UserRepositoryCommand = new UserRepositoryCommand(_context);
        }


        public IUserRepositoryCommand UserRepositoryCommand { get; }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}