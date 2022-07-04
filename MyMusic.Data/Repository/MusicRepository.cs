using MyMusic.Core.Interfaces;
using MyMusic.Core.Models;
using MyMusic.Data.DataContext;

namespace MyMusic.Data.Repository
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(MyMusicDbContext dbContext) : base(dbContext)
        {
        }
    }
}
