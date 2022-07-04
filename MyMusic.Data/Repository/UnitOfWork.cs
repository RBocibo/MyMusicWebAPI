using MyMusic.Core.Interfaces;
using MyMusic.Data.DataContext;

namespace MyMusic.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMusicDbContext _context;
        public UnitOfWork(MyMusicDbContext context)
        {
            _context = context;
        }
        public async Task CommitAsyc()
        {
            await _context.SaveChangesAsync();
        }
    }
}
